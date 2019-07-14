using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Gipfel.WCF.TaskOne
{
	[ServiceContract]
	public interface IWcfService
	{

		[OperationContract]
		string GetData(int value);

		[OperationContract]
		Order GetDataUsingDataContract(Order order);

		// TODO: Добавьте здесь операции служб
	}

	

	// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
	[DataContract]
	public class Order
	{

		public long id;
		public long inventoryId;

		public long customerId;

		public string comment;
		public DateTime dateEvent;


		[DataMember]
		public long OrderId
		{
			get => id;
			set => id = value;
		}

		[DataMember]
		public long InventoryId
		{
			get => inventoryId;
			set => inventoryId = value;
		}

		[DataMember]
		public long CustomerId
		{
			get => customerId;
			set => customerId = value;
		}

		[DataMember]
		public string Comment
		{
			get => comment;
			set => comment = value;
		}

		[DataMember]
		public DateTime DateEvent
		{
			get => dateEvent;
			set => dateEvent = value;
		}
	}
}
