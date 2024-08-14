using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxHelper
{
	class ExplosivesController
	{
		public static List<Explosive> Explosives { get; set; } = new();
		public static void InitExplosivesTable()
		{
			//Structures.Add(new Structure() { Name = "test", Tier = 1, Count = 0 });
			ExplosivesController.Explosives = Database.LoadExplosivesTable();
		}
		public static void RecalculateNeededCount(double totalHP, decimal totalNormalIntegrity, decimal totalConcreteIntegrity)
		{
			double effectiveNormalHP = totalHP * (double)totalNormalIntegrity;
			double effectiveConcretelHP = totalHP * (double)totalConcreteIntegrity;

			foreach (Explosive ex in Explosives)
			{
				//ex.FullDestroyCount = totalHP / ex.Damage;
				ex.FullDestroyCount = (long)Math.Round(effectiveNormalHP / (double)(ex.GetTotalDamage * ex.DestructionModifier), 0, MidpointRounding.ToPositiveInfinity);
				ex.FullDestroyConcreteCount = (long)Math.Round(effectiveConcretelHP / (double)(ex.GetTotalDamage * ex.ConcreteModifier), 0, MidpointRounding.ToPositiveInfinity);
				ex.DmgPerShot = (long)(ex.GetTotalDamage * ex.DestructionModifier);
				ex.DmgPerShotConcrete = (long)(ex.GetTotalDamage * ex.ConcreteModifier);
			}
		}
	}
}
