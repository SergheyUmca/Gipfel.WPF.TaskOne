using System.Collections.Generic;
using System.Linq;
using Gipfel.WPF.TaskOne.Models;
using Gipfel.WPF.TaskOne.Models.IRepositories;

namespace Gipfel.WPF.TaskOne.Repositories
{
	public class InventoryRepository : IInventoryRepository
	{
		public List<Inventory> GetInventories()
		{

			using (var db = new InventoryDContext())
			{
				return db.Inventory.ToList();
			}
		}

		public Inventory GetInventoryByName( string pInventoryName)
		{

			using (var db = new InventoryDContext())
			{
				var getInventoryByName = db.Inventory.Where(x => x.Name == pInventoryName);
				return getInventoryByName.FirstOrDefault();
			}
		}

		public long SaveInventory(Inventory pInventory)
		{
			using (var db = new InventoryDContext())
			{
				var saveInventory = db.Inventory.Add(pInventory);
				db.SaveChanges();

				return saveInventory.Id;
			}
		}
	}
}
