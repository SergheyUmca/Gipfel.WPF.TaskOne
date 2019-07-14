using System.Collections.Generic;

namespace Gipfel.WPF.TaskOne.Models.IRepositories
{
	public interface IInventoryRepository
	{
		List<Inventory> GetInventories();
		long SaveInventory(Inventory pInventory);

		Inventory GetInventoryByName(string pInventoryName);
	}
}
