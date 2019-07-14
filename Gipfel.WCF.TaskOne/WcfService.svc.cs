using System;

namespace Gipfel.WCF.TaskOne
{
	public class Service1 : IWcfService
	{
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

		public Order GetDataUsingDataContract(Order order)
		{
			if (order == null)
			{
				throw new ArgumentNullException("order");
			}

			return order;
		}
	}
}
