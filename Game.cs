using System;
using System.Linq;

namespace DungeonExplorer
{
	public class Game
	{
		private Player player;
		private Room currentRoom;
		private GameMap gameMap;

		public void Start()
		{
			Console.WriteLine("Welcome. You Have entered the Dungeon Exploration");
			Console.Write("Enter your name explorer: ");
			string name = Console.ReadLine();
			name = string.IsNullOrWhiteSpace(name) ? "Adventurer" : name;

			player = new Player(name, 100);
			gameMap = new GameMap();
			gameMap.Initialize();


			currentRoom = gameMap.StartingRoom;
			Console.WriteLine($"\nWelcome, {player.Name}! Your adventure begins...\n");

			bool running = true;
			while (running)
			{
				Console.WriteLine("\nOptions:");
				Console.WriteLine("1, View Room Description");
				Console.WriteLine("2. Pick Up Item");
				Console.WriteLine("3. View Inventory");
				Console.WriteLine("4. Use Item");
				Console.WriteLine("5. Fight Monster");
				Console.WriteLine("6. Move to Another Room");
				Console.WriteLine("7. Exit Game");
				Console.Write("Choice: ");

				switch (Console.ReadLine())
				{
					case "1":
						currentRoom.ShowDescription();
						break;

					case "2":
						PickUpItem();
						break;

					case "3":
						player.Inventory.ShowInventory();
						break;

					case "4":
						UseItem();
						break;

					case "5":
						FightMonster();
						break;

					case "6":
						MoveToNextRoom();
						break;

					case "7":
						Console.WriteLine("I hope to see you again explorer");
						running = false;
						break;

					default:
						Console.WriteLine("Invalid Choice");
						break;
				}

            } 
		}

		private void PickUpItem()
		{
			Console.Write("Enter item name to Pick up: ");
			string itemName = Console.ReadLine();
			var item = currentRoom.TakeItem(itemName);
			if(item != null )
			{
				player.Inventory.AddItem(item);
			}
		}

		private void UseItem()
		{
			Console.WriteLine("Enter item name to use");
			string name = Console.ReadLine();
			player.Inventory.UseItem(name, player);
		}

		private void FightMonster()
		{
			var monsters = currentRoom.GetMonsters();
			if (!monsters.Any())
			{
				Console.WriteLine("No Monsters in this room");
				return;
			}

			Console.WriteLine("choose a monster to attack:");
			for(int i = 0; i < monsters.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {monsters[i].Name} (HP: {monsters[i].Health})");
			}

			if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= monsters.Count)
			{
				var target = monsters[choice - 1];
				player.Attack(target);
				if (target.IsAlive)
				{
					target.Attack(player);
				}
				else
				{
					Console.WriteLine($"{target.Name} has been defeated!");
					currentRoom.RemoveDeadMonsters();
				}

				if (!player.IsAlive)
				{
					Console.WriteLine("You have Died. Game Over");
					Environment.Exit(0);
				}
			}
			else
			{
				Console.WriteLine("Invalid Monster");
			}
		}

		private void MoveToNextRoom()
		{
			var adjacentRooms = gameMap.GetAdjacentRooms(currentRoom);

			Console.WriteLine("\nAvailable Rooms:");
			for (int i = 0; i < adjacentRooms.Count(); i++)
			{
				Console.WriteLine($"{i + 1}. {adjacentRooms[i].Description}");
			}

			Console.Write("Choose a room to enter: ");
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice >= 1 && choice <= adjacentRooms.Count())
            {
                currentRoom = adjacentRooms[choice - 1];
                Console.WriteLine($"You move to: {currentRoom.Description}");
            }
            else
            {
                Console.WriteLine("Invalid room selection.");
            }
        }
	}
}
