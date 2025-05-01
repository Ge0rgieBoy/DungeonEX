using System;

namespace DungeonExplorer
{
	public class GameMap
	{
		private Dictionary<string, Room> rooms = new();

		public Room StartingRoom => rooms.Count > 0 ? rooms.Values.First() : null;

		public void Initialize()
		{
			var room1 = new Room("Dusty stone chamber.");
			var room2 = new Room("Dark corridor.");
			var room3 = new Room("Treasure Room!");

			room1.AddItem(new Weapon("Sword," 10));
			room2.AddMonster(new Monster("Slime", 30, 5));
			room3.AddItem(new Potion("Health Potion", 20));

			AddRoom("Start", room1);
			AddRoom("Hallway", room2);
			AddRoom("Treasure", room3);
		}

		public void AddRoom(string name, Room room)
		{
			rooms[name] = room;
		}

		public List<Room> GetAdjacentRooms(Room current)
		{
			return rooms.Values.Where(rooms => rooms != current).ToList();
		}


	}
}
