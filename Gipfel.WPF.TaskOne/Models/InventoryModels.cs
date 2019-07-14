using System;
using System.Data.Entity;

namespace Gipfel.WPF.TaskOne.Models
{
	public class InventoryDContext : DbContext
	{
		public InventoryDContext() :
			base("BaseDb")
		{

		}

		public virtual DbSet<Inventory> Inventory { get; set; }
	}
	public class Inventory
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public double? Price { get; set; }
	}
}
