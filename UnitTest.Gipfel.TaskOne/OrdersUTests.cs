using System;
using Gipfel.WPF.TaskOne;
using Gipfel.WPF.TaskOne.Models;
using Gipfel.WPF.TaskOne.Models.IRepositories;
using Gipfel.WPF.TaskOne.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Gipfel.TaskOne
{

	[TestClass]
	public class OrdersUTests
	{
		private static IOrderRepository _OrderRepository => new OrderRepository();

		[TestMethod]
		public void GetOrders()
		{
			var getOrders = _OrderRepository.GetOrders();

			Assert.IsNotNull(getOrders);
		}

		[TestMethod]
		public void SaveOrders()
		{

			var vOrder = new Order
			{
				InventoryId = 1,
				CustomerId = 1,
				Comment =  "Comment",
				DateEvent = DateTime.Now
			};
			var saveOrder = _OrderRepository.SaveOrder(vOrder);

			Assert.AreNotEqual(saveOrder, 0);
		}

		[TestMethod]
		public void CompleteOrders()
		{

			var completeOrders = DatesHelper.CompleteOrdersWithRandom();

			Assert.IsNotNull(completeOrders);
		}

		[TestMethod]
		public void GetViewOrders()
		{
			var getOrders = _OrderRepository.GetViewOrders(10);

			Assert.IsNotNull(getOrders);
		}

	}
}
