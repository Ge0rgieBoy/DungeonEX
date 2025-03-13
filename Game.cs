using System;
using System.Media;

namespace DungeonExplorer
{
    /// <summary>
    /// Handles main flow of dungeon crawler game.
    /// Initialises player and starting room, manages user interaction.
    /// </summary>
    public class Game
    {
        private Player player;
        private Room currentRoom;

        /// <summary>
        /// Starts game manages game loop.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome. You Have entered the Dungeon Exploration");
            Console.WriteLine("Enter player name: ");
            string name = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Adventurer";
                Console.WriteLine("No Name Entered. Name: 'Adventurer'.");
            }

            
            player = new Player(name, 100);
            currentRoom = new Room("You have entered what appears to be an old forgotten mineshaft with only one flickering torch", "treasure box");

            Console.Clear();
            Console.WriteLine($"Hello, {player.GetName()}! Your adventure begins....\n");

            
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nWhere would you like to start?");
                Console.WriteLine("1. Get Room Description");
                Console.WriteLine("2. Pick up item in the corner");
                Console.WriteLine("3. View your Player Status");
                Console.WriteLine("4. Enter Next Room");
                Console.WriteLine("5. Exit Game");

                Console.WriteLine("Enter choice (1-4); ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowRoomDescription();
                        break;

                    case "2":
                        TryPickUpItem();
                        break;

                    case "3":
                        player.ShowStatus();
                        break;

                    case "4":
                        TryMoveToRoom();
                        break;

                    case "5":
                        isRunning = false;
                        Console.WriteLine("Come back soon and enjoy the deep depths another time.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try entering an number from 1 - 5.");
                        break;
                }
            }

            
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here
            }
        }

        /// <summary>
        /// Displays current room description and any items.
        /// </summary>
        private void ShowRoomDescription()
        {
            Console.WriteLine("\n" + currentRoom.GetDescription());
            if (currentRoom.HasItem())
            {
                Console.WriteLine($"You find a {currentRoom.GetItem()} in the corner of the room.");
            }
            else
            {
                Console.WriteLine("There is nothing else to pick up");
            }
        }

        /// <summary>
        /// Trys to pick up item from room and adds to players inventory.
        /// </summary>
        private void TryPickUpItem()
        {
            if (currentRoom.HasItem())
            {
                string item = currentRoom.TakeItem();
                player.PickUpItem(item);
            }
            else
            {
                Console.WriteLine("No item appears to be here.");
            }
        }

        /// <summary>
        /// Handles player attempt at moving to another room.
        /// </summary>
        private void TryMoveToRoom()
        {
            Console.WriteLine("There are no other rooms.");
            Console.WriteLine("Keep searching for clues in this room.");
        }

      
      
    }
}