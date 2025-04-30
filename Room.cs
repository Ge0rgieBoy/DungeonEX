using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    ///  Represents a room in the dungeon with a description, items, and monsters.
    /// </summary>
    public class Room
    {
        public string Description { get; private set; }
        private List<Item> items;
        private List<Monster> monsters;
	

	public Room(string description)
        {
            Description = description;
            items = new List<Item>();
            monsters = new List<Monster>();
        }

        public void AddItem(Item item) => items.Add(item);
        public void AddMonster(Monster monster) => monsters.Add(monster);

        public void ShowDescription()
        {
            Console.WriteLine(Description);

            if (items.Any())
            {
                Console.WriteLine("You stumble apon the following items:");
                foreach (var item in items)
                    Console.WriteLine($" - {item.Name}");

            }
            else
            {
                Console.WriteLine("There are no items in this room.");
            }

            if (monsters.Any())
            {
                Console.WriteLine("Monsters in the room:");
                foreach (var monster in monsters)
                    Console.WriteLine($" - {monster.Name} (HP: {monster.Health})");
            }
            else
            {
                Console.WriteLine("The room is eerily quiet... suspisious");
            }
        }

        public Item TakeItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                items.Remove(item);
                return item;
            }

            Console.WriteLine("That item isn't in this room.");
            return null;
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        public void RemoveDeadMonsters()
        {
            monsters.RemoveAll(monsters => !monsters.IsAlive);
        }
    }
}