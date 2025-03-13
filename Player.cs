using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents player in dungeon crawler.
    /// Tracks player's name, health, and inventory item.
    /// </summary>
    public class Player
    {
        public string name;
        public int health;
        private string inventoryItem;

        /// <summary>
        /// States there is a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="health">The starting health of the player.</param>
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

        /// <summary>
        /// Adds item to players inventory if empty.
        /// </summary>
        /// <param name="item">The item that can be picked up.</param>
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

        /// <summary>
        /// Displays players current status this being name, health, and inventory item.
        /// </summary>
        public void ShowStatus()
        {
            Console.WriteLine($"Player: {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Inventory: {(inventoryItem ?? "Empty")}");
        }
        
    }
}