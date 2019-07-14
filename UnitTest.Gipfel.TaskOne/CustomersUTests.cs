using System;
using Gipfel.WPF.TaskOne;
using Gipfel.WPF.TaskOne.Models;
using Gipfel.WPF.TaskOne.Models.IRepositories;
using Gipfel.WPF.TaskOne.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Gipfel.TaskOne
{

	[TestClass]
	public class CustomersUTests
	{
		private static ICustomerRepository _CustomerRepository => new CustomerRepository();
		private static Random _random = new Random();

		[TestMethod]
		public void GetCustomers()
		{
			var getCustomers = _CustomerRepository.GetCustomers();

			Assert.IsNotNull(getCustomers);
		}



		[TestMethod]
		public void SaveCustomer()
		{
			var vCustomerSuffix = _random.Next();
			var vCustomer = new Customer
			{
				Name = $"Customer_{vCustomerSuffix}",
				Vip = vCustomerSuffix % 2 == 0
			};
			var saveCustomer = _CustomerRepository.SaveCustomer(vCustomer);

			Assert.AreNotEqual(saveCustomer, 0);
		}


		[TestMethod]
		public void CompleteCustomers()
		{
			var completeCustomer = DatesHelper.CompleteCustomerWithRandom();

			Assert.IsNotNull(completeCustomer);
		}
	}

}
