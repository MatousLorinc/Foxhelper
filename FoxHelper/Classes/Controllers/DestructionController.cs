using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxHelper
{
	class DestructionController
	{
		public static List<Structure> Structures { get; set; } = new();

		public static double TotalHealth = 0;
		public static decimal TotalIntegrity = 0;
		public static decimal DrynessModifier = 1;
		public static void InitStructuresTable()
		{
			//Structures.Add(new Structure() { Name = "test", Tier = 1, Count = 0 });
			DestructionController.Structures = Database.LoadStructuresTable();
		}
		public static double GetWetConcreteDamageModifier(double dryness)
		{
			double maxDmgModifier = 10;
			if(dryness <= 2.4)
			{
				return maxDmgModifier;
			}
			else
			{
				//modifiers = -(((24/dryness)-11)/((double)10));
				return 24 / dryness;
			}
		}

		public static double GetTotalHealth
		{
			get
			{
				TotalHealth = Structures.Where(x => x.Count > 0).Sum(x => x.Health * x.Count);
				return TotalHealth;
			}
		}
		public static double GetTotalNormalHealth
		{
			get
			{
				return Structures.Where(x => x.Count > 0 && x.Tier < 3).Sum(x => x.Health * x.Count);
			}
		}
		public static double GetTotalConcreteHealth
		{
			get
			{
				return Structures.Where(x => x.Count > 0 && x.Tier == 3).Sum(x => x.Health * x.Count);
			}
		}
		public static decimal GetTotalIntegrity
		{
			get
			{
				decimal totalIntegrity = 1;
				foreach (Structure s in Structures.Where(x => x.Count > 0))
				{
					for (int i = 0; i < s.Count; i++)
						totalIntegrity *= s.Integrity;
				}
				TotalIntegrity = totalIntegrity;
				return totalIntegrity;
			}
		}
		public static decimal GetTotalNormalIntegrity
		{
			get
			{
				decimal totalIntegrity = 1;
				foreach (Structure s in Structures.Where(x => x.Count > 0 && x.Tier < 3))
				{
					for(int i = 0; i < s.Count; i++)
						totalIntegrity *= s.Integrity;
				}
				return totalIntegrity;
			}
		}
		public static decimal GetTotalConcreteIntegrity
		{
			get
			{
				decimal totalIntegrity = 1;
				foreach (Structure s in Structures.Where(x => x.Count > 0 && x.Tier == 3))
				{
					for (int i = 0; i < s.Count; i++)
						totalIntegrity *= s.Integrity;
				}
				return totalIntegrity;
			}
		}

	}
}
