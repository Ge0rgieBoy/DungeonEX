using System;

namespace DungeonExplorer
{
	public class Potion : Item
	{
		public int HealAmount { get; private set; }

		public Potion(string name, int healAmount) : base(name)
		{
			HealAmount = healAmount;
		}

		public override void Use(Player player)
		{
			player.Heal(HealAmount);
			Console.WriteLine($"You used {Name} amd restored {HealAmount} health.");
		}

		public void ShowStatus(Player player)
		{
			Console.WriteLine($"Player: {player.Name}");
			Console.WriteLine($"Health; {player.Health}");
			player.Inventory.ShowInventory();
		}
	}
}
