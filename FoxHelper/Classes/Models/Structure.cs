using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxHelper
{
	class Structure
	{
		public static long lastID = 0;
		public long ID { get; set; }
		public long Health { get; set; }
		public decimal Integrity { get; set; }
		public long BmatCost { get; set; }
		public long ShovelCost { get; set; }
		public long ConcreteCost { get; set; }
		public long RepairCost { get; set; }
		public string Name { get; set; }
		public long Count { get; set; }
		public long Tier { get; set; }
		public Structure()
		{
			lastID++;
			ID = lastID;
		}
	}
}
