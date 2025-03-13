using System;
using System.Media;

namespace DungeonExplorer
{
    public class Game
    {
        private Player player;
        private Room currentRoom;

        // Starts the game and handles the main game loop
        public void Start()
        {
            Console.WriteLine("Welcome. You Have entered the Dungeon Exploration");
            Console.WriteLine("Enter player name: ");
            string name = Console.ReadLine();

            // Default player name if none entered
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Adventurer";
                Console.WriteLine("No Name Entered. Name: 'Adventurer'.");
            }

            // Initialise player and room
            player = new Player(name, 100);
            currentRoom = new Room("You have entered what appears to be an old forgotten mineshaft with only one flickering torch and a treasure box in the corner");

            Console.Clear();
            Console.WriteLine($"Hello, {player.GetName()}! Your adventure begins....\n");

            // Main game loop
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

            // Change the playing logic into true and populate the while loop
            bool playing = false;
            while (playing)
            {
                // Code your playing logic here
            }
        }

        // Displays room description and item (if any)
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

        // Attempt at picking an item from the room
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

        // Placeholder for room navigation
        private void TryMoveToRoom()
        {
            Console.WriteLine("There are no other rooms.");
            Console.WriteLine("Keep searching for clues in this room.");
        }

        // Entry point
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}