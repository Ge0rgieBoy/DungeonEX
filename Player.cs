using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string name;
        public int health;
        private string inventoryItem;

        // Stating players name, health, and empty inventory
        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
            this.inventoryItem = null;
        }

        // Gets player name
        public string GetName()
        {
            return name;
        }

        // Gets player current health
        public int GetHealth()
        {
            return health;
        }

        // Attempt at picking up an item if empty inventory
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

        // Displays players name, health, and inventory status
        public void ShowStatus()
        {
            Console.WriteLine($"Player: {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Inventory: {(inventoryItem ?? "Empty")}");
        }
        
    }
}