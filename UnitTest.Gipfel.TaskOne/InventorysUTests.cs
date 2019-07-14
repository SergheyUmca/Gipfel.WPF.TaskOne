using System;
using Gipfel.WPF.TaskOne;
using Gipfel.WPF.TaskOne.Models;
using Gipfel.WPF.TaskOne.Models.IRepositories;
using Gipfel.WPF.TaskOne.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Gipfel.TaskOne
{

	[TestClass]
	public class InventoriesUTests
	{
		private static IInventoryRepository _InventoryRepository => new InventoryRepository();
		private static Random _random = new Random();

		[TestMethod]
		public void GetInventories()
		{
			var getInventories = _InventoryRepository.GetInventories();

			Assert.IsNotNull(getInventories);
		}


		[TestMethod]
		public void GetInventoriesByName()
		{
			var getInventory = _InventoryRepository.GetInventoryByName("");

			Assert.IsNotNull(getInventory);
		}

		[TestMethod]
		public void SaveInventory()
		{
			var vInventory = new Inventory
			{
				Name = $"Inventory_{ _random.Next()}",
				Price = _random.Next(1,100000) + _random.NextDouble()
				
			};
			var saveInventory = _InventoryRepository.SaveInventory(vInventory);

			Assert.AreNotEqual(saveInventory, 0);
		}


		[TestMethod]
		public void CompleteInventory()
		{
			var completeInventory = DatesHelper.CompleteInventoryWithRandom();

			Assert.IsNotNull(completeInventory);
		}
	}
}
