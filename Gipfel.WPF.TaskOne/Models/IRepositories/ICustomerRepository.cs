using System.Collections.Generic;

namespace Gipfel.WPF.TaskOne.Models.IRepositories
{
	public interface ICustomerRepository
	{
		List<Customer> GetCustomers();
		long SaveCustomer(Customer pCustomer);
		Customer GetCustomerByName(string pCustomerName);
	}
}
