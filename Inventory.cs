using System;
using System.Collection.Genric;
using System.Linq;

namespace DungeonExplorer
{
	public class Inventory
	{
		private List<Item> items = new 

		public void AddItem(Item item)
		{
			items.Add(item);
			Console.WriteLine($"{item.Name} added to inventory.");
		}

		public void ShowInventory()
		{
			if (!items.Any()) ;
			{
				Console.WriteLine($"Inventory is empty.");
				return;
			}

			Console.WriteLine("Inventory");
			foreach (var item in items)
			{
				Console.WriteLine($"- {item.Name}");
			}
		}

        public IEnumerable<Weapon> GetWeapon() => items.OfType<Weapon>();
        public IEnumerable<Potion> GetPotion() => items.OfType<Potion>();

		public Item GetItemByName(string name) =>
			items.FirstOrDefault(items => i.Names.Equals(name, StringComparison.OrdinalIgnoreCase));

		public void UseItem(string name, Player player)
		{
			var item = GetItemByName(name);
			if (item != null)
			{
				item.Use(player);
				items.Remove(item);
			}
			else
			{
				Console.WriteLine("Item not found in inventory");
			}
		}
	}
}
