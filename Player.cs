using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string name;
        public int health;
        private string inventoryItem;

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
            this.inventoryItem = null;
        }

        public string GetName()
        {
            return name;
        }

        public int GetHealth()
        {
            return health;
        }

        public void PickUpItem(string item)
        {
            if (inventoryItem == null)
            {
                inventoryItem = item;
                Console.WriteLine($"You pick up {item}.");
            }
            else
            {
                Console.WriteLine("Inventory full. Max of one item allowed to be carried per room");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Player: {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Inventory: {(inventoryItem ?? "Empty")}");
        }
        
    }
}