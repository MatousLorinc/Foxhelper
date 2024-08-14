using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxHelper
{
	class Credits
	{
		public static string GetCredits
		{
			get
			{
				StringBuilder sb = new();
				sb.AppendLine("This software simulates inputs from keyboard and mouse. Anvirus may not like it :)");
				sb.AppendLine();
				sb.AppendLine("Made by : Matson");
				//sb.AppendLine("Info icon made by Freepik https://www.freepik.com");
				//sb.AppendLine("Cursor icon made by Pixel perfect https://www.flaticon.com/authors/pixel-perfect");
				//sb.AppendLine("Destruction icon made by Adib Sulthon https://www.flaticon.com/authors/adib-sulthon");
				//sb.AppendLine("Concrete icon made by monkik https://www.flaticon.com/authors/monkik");
				sb.AppendLine();
				sb.AppendLine("version 0.3.0.");
				sb.AppendLine("release date 21-10-2023");
				return sb.ToString();
			}
		}
		// Datamining: kaybet
		// Coding : Matson
		// Info icon made by Freepik https://www.freepik.com
		// Cursor icon made by Pixel perfect https://www.flaticon.com/authors/pixel-perfect
		// Destruction icon made by Adib Sulthon https://www.flaticon.com/authors/adib-sulthon
		// Concrete icon made by monkik https://www.flaticon.com/authors/monkik
		// https://www.flaticon.com/
	}
}
