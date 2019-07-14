using System.Data.Entity;

namespace Gipfel.WPF.TaskOne.Models
{
	public class CustomerDContext : DbContext
	{
		public CustomerDContext() :
			base("BaseDb")
		{

		}

		public virtual DbSet<Customer> Customer { get; set; }
	}

	public class Customer
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool Vip { get; set; }
	}
}
