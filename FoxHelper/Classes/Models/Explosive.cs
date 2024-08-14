using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxHelper
{
	class Explosive
	{
		public static long lastID = 0;
		public long ID { get; set; }
		public string Name { get; set; }
		public long Damage { get; set; }
		public decimal DamageModifier { get; set; }
		public decimal DestructionModifier { get; set; }
		public decimal ConcreteModifier { get; set; }
		public long FullDestroyCount { get; set; }
		public long FullDestroyConcreteCount { get; set; }
		public long DmgPerShot { get; set; }
		public long DmgPerShotConcrete { get; set; }

		public decimal GetTotalDamage
		{
			get
			{
				return DamageModifier * Damage;
			}
		}

		public Explosive()
		{
			lastID++;
			ID = lastID;
		}
	}
}
