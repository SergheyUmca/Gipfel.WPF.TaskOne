using System.Collections.Generic;

namespace Gipfel.WPF.TaskOne.Models.IRepositories
{
	public interface IOrderRepository
	{
		List<Order> GetOrders( int? pCount = null);
		long SaveOrder(Order pOrder);
		List<long> SaveOrders(List<Order> pOrders);
		List<OrderViewModel> GetViewOrders(int? pCount = null);
		bool UpdateOrders(List<Order> pOrders);
	}
}
