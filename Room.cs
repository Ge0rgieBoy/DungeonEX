namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;

        // States the room's description and item
        public Room(string description, string item)
        {
            this.description = description;
            this.item = item;
        }

        // Returns room descritpion 
        public string GetDescription()
        {
            return description;
        }

        // Returns item in current room (if any)
        public string GetItem()
        {
            return item;
        }

        // Removes and returns item from room
        public string TakeItem()
        {
            string temp = item;
            item = null;
            return temp;
        }

        // See's if there is currently an item in the room 
        public bool HasItem()
        {
            return item != null;
        }
    }
}