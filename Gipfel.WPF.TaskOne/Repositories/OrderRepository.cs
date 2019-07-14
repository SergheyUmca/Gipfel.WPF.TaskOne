using Gipfel.WPF.TaskOne.Models.IRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gipfel.WPF.TaskOne.Models;

namespace Gipfel.WPF.TaskOne.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public List<Order> GetOrders (int? pCount)
		{
			
			using (var db = new OrderDContext())
			{
				return pCount == null ? db.Orders.ToList() : db.Orders.Take((int)pCount).ToList();
			}
		}

		public List<OrderViewModel> GetViewOrders( int? pCount = null)
		{
			using (var db = new OrderDContext())
			{
				if (pCount != null)
				{
					var getViewOrders = (from order in db.Orders
						join customer in db.Customers on order.CustomerId equals customer.Id
						join inventory in db.Inventories on order.InventoryId equals inventory.Id
						select new OrderViewModel
						{
							CustomerName = customer.Name,
							DateEvent = order.DateEvent,
							InventoryName = inventory.Name,
							OrderId = order.Id
						}).Take((int)pCount);

					return getViewOrders.ToList();
				}
				else
				{
					var getViewOrders = from order in db.Orders
						join customer in db.Customers on order.CustomerId equals customer.Id
						join inventory in db.Inventories on order.InventoryId equals inventory.Id
						select new OrderViewModel
						{
							CustomerName = customer.Name,
							DateEvent = order.DateEvent,
							InventoryName = inventory.Name,
							OrderId = order.Id
						};

					return getViewOrders.ToList();
				}

			}
		}

		public long SaveOrder(Order pOrder)
		{
			using (var db = new OrderDContext())
			{
				var saveOrder = db.Orders.Add(pOrder);
				db.SaveChanges();

				return saveOrder.Id;
			}
		}

		public List<long> SaveOrders(List<Order> pOrders)
		{
			using (var db = new OrderDContext())
			{
				var saveOrder = db.Orders.AddRange(pOrders);
				db.SaveChanges();

				return saveOrder.Select(x => x.Id).ToList();
			}
		}

		public bool UpdateOrders(List<Order> pOrders)
		{
			using (var db = new OrderDContext())
			{
				foreach (var order in pOrders)
				{
					var updateOrders = db.Orders.SingleOrDefault(x => x.Id == order.Id);
					updateOrders.CustomerId = order.CustomerId;
					updateOrders.DateEvent = order.DateEvent;
					updateOrders.InventoryId = order.InventoryId;

					db.SaveChanges();
				}

				return true;
			}
		}
	}
}
