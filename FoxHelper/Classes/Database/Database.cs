using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FoxHelper
{
	class Database
	{
    /// <summary>
    /// file names containg database data
    /// </summary>
    public const string DatabaseFilename = "Database.json";
    public const string StructuresFilename = "Structures.json";
    public const string ExplosivesFilename = "Explosives.json";
    private const string DatabaseDirectory = "Database";
    /// <summary>
    /// Gets fullpath to database file
    /// </summary>
    public static string GetDatabaseFilePath(string filename)
    {
      return Path.Combine(System.AppContext.BaseDirectory, DatabaseDirectory, filename);
    }
    /// <summary>
    /// using Newtonsoft deserialze user setting json file into Config class instance
    /// </summary>
    /// <returns>Config instance with current user setting</returns>
    public static List<Structure> LoadStructuresTable()
    {
      try
      {
        return JsonConvert.DeserializeObject<List<Structure>>(File.ReadAllText(GetDatabaseFilePath(StructuresFilename)));
      }
      catch
      {
        Log.WritePrint("Failed to load structures data from file");
        return new();
      }
    }

    public static List<Explosive> LoadExplosivesTable()
    {
      try
      {
        return JsonConvert.DeserializeObject<List<Explosive>>(File.ReadAllText(GetDatabaseFilePath(ExplosivesFilename)));
      }
      catch
      {
        Log.WritePrint("Failed to load Explosives data from file");
        return new();
      }
    }

  }
}
