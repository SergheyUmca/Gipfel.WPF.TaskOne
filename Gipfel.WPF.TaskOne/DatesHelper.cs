
using System;
using System.Collections.Generic;
using System.Linq;
using Gipfel.WPF.TaskOne.Models;
using Gipfel.WPF.TaskOne.Models.IRepositories;
using Gipfel.WPF.TaskOne.Repositories;

namespace Gipfel.WPF.TaskOne
{
	public static class DatesHelper
	{
		private static IInventoryRepository _inventoryRepository => new InventoryRepository();
		private static ICustomerRepository _customerRepository => new CustomerRepository();
		private static IOrderRepository _orderRepository => new OrderRepository();
		private static readonly Random _random = new Random();

		public static List<long> CompleteCustomerWithRandom(int pCount = 3)
		{
			var vResult = new List<long>();
			for (var i = 0; i < pCount; i++)
			{
				var vCustomerSuffix = _random.Next();
				var vCustomer = new Customer
				{
					Name = $"Customer_{vCustomerSuffix}",
					Vip = vCustomerSuffix % 2 == 0
				};
				var saveCustomer = _customerRepository.SaveCustomer(vCustomer);
				if (saveCustomer == 0)
				{
					continue;
				}

				vResult.Add(saveCustomer);
			}

			return vResult;
		}

		public static List<long> CompleteInventoryWithRandom(int pCount = 3)
		{
			var vResult = new List<long>();
			for (var i = 0; i < pCount; i++)
			{
				var vInventory = new Inventory
				{
					Name = $"Inventory_{ _random.Next()}",
					Price = _random.Next(1, 100000) + _random.NextDouble()

				};
				var saveInventory = _inventoryRepository.SaveInventory(vInventory);
				if (saveInventory == 0)
				{
					continue;
				}

				vResult.Add(saveInventory);
			}

			return vResult;
		}

		public static List<long> CompleteOrdersWithRandom(int pOrderCount = 5, int pCustomerCount = 3, int pInventoryCount = 3)
		{
			var vResult = new List<long>();
			var completeCustomers = CompleteCustomerWithRandom();
			var completeInventories = CompleteInventoryWithRandom();

			for (var i = 0; i < pOrderCount; i++)
			{
				var vOrder = new Order
				{
					InventoryId = completeCustomers.Count > i ? completeCustomers[i] : completeCustomers[0],
					CustomerId = completeInventories.Count > i ? completeInventories[i] : completeInventories[0],
					Comment = "Comment",
					DateEvent = DateTime.Now.AddDays(-i)
				};
				var completeOrders = _orderRepository.SaveOrder(vOrder);
				if (completeOrders == 0)
				{
					continue;
				}

				vResult.Add(completeOrders);
			}

			return vResult;
		}

		public static Customer GetCustomerByName(string pCustomerName)
		{
			return _customerRepository.GetCustomerByName(pCustomerName);
		}

		public static Inventory GetInventoryByName(string pInventoryName)
		{
			return _inventoryRepository.GetInventoryByName(pInventoryName);
		}

		public static List<OrderViewModel> GetOrdersView(int? pCountItems = null )
		{
			var vResult = _orderRepository.GetViewOrders(pCountItems);

			return vResult;
		}

		public static List<Order> GetOrders( int? pCount = null)
		{
			return _orderRepository.GetOrders(pCount);
		}

		public static List<long> SaveOrders(List<Order> pOrders)
		{
			return _orderRepository.SaveOrders(pOrders);
		}

		public static bool UpdateOrders(List<Order> pOrders)
		{
			return _orderRepository.UpdateOrders(pOrders);
		}

		public static bool SaveOrderView(List<OrderViewModel> pOrders)
		{
			try
			{
				var vOldOrderList = GetOrders(pOrders.Count);

				var vNewOrderList = pOrders.Select(x => new Order
				{
					CustomerId = GetCustomerByName(x.CustomerName).Id,
					InventoryId = GetInventoryByName(x.InventoryName).Id,
					DateEvent = x.DateEvent,
					Id = x.OrderId,
				}).Where(x => !vOldOrderList.Exists(o => o.Id == x.Id)).ToList();

				if (vNewOrderList.Count > 0)
				{
					var saveOrders = SaveOrders(vNewOrderList);
					if (saveOrders.Count == 0)
					{
						return false;
					}
				}

				var vModifiedOrderList = pOrders.Select(x => new Order
				{
					CustomerId = GetCustomerByName(x.CustomerName).Id,
					InventoryId = GetInventoryByName(x.InventoryName).Id,
					DateEvent = x.DateEvent,
					Id = x.OrderId,
				}).Where(x => vOldOrderList.Exists(o => o.Id == x.Id && (o.CustomerId != x.CustomerId || o.InventoryId != x.InventoryId || o.DateEvent != x.DateEvent))).ToList();
				return vModifiedOrderList.Count > 0 && UpdateOrders(vModifiedOrderList);
			}
			catch (Exception e)
			{
				return false;
			}
			

		}

	}
}
