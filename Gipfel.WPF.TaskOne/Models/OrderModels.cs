using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Gipfel.WPF.TaskOne.Models
{
	public class OrderDContext : DbContext
	{
		public OrderDContext() :
			base("BaseDb")
		{

		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
	}

	public class Order
	{
		[Key]
		public long Id { get; set; }
		public long InventoryId { get; set; }

		public long CustomerId { get; set; }

		public string Comment { get; set; }

		public DateTime DateEvent { get; set; }
	}


	public class OrderViewModel
	{
		public long OrderId { get; set; }
		public string CustomerName { get; set; }
		public string InventoryName { get; set; }
		public DateTime DateEvent { get; set; }
	}
}
