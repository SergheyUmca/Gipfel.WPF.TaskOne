using System.Collections.Generic;
using System.Linq;
using Gipfel.WPF.TaskOne.Models;
using Gipfel.WPF.TaskOne.Models.IRepositories;

namespace Gipfel.WPF.TaskOne.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		public List<Customer> GetCustomers()
		{
			using (var db = new CustomerDContext())
			{
				return db.Customer.ToList();
			}
		}

		public Customer GetCustomerByName(string pCustomerName)
		{
			using (var db = new CustomerDContext())
			{
				var getCustomerByName = db.Customer.FirstOrDefault(x => x.Name == pCustomerName);
				return getCustomerByName;
			}
		}

		public long SaveCustomer(Customer pCustomer)
		{
			using (var db = new CustomerDContext())
			{
				var saveCustomer = db.Customer.Add(pCustomer);
				db.SaveChanges();

				return saveCustomer.Id;
			}
		}
	}
}
