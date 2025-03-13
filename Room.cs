namespace DungeonExplorer
{
    /// <summary>
    /// Represents single room in a dungeon with descriptions and an optional item.
    /// </summary>
    public class Room
    {
        private string description;
        private string item;

        /// <summary>
        /// States new instance of <see cref="Room"/> class.
        /// </summary>
        /// <param name="description">Description of the room.</param>
        /// <param name="item">item present in room.</param>
        public Room(string description, string item)
        {
            this.description = description;
            this.item = item;
        }

        /// <summary>
        /// Gets description of room.
        /// </summary>
        /// <returns>Description string.</returns>
        public string GetDescription()
        {
            return description;
        }

        
        public string GetItem()
        {
            return item;
        }

        
        public string TakeItem()
        {
            string temp = item;
            item = null;
            return temp;
        }

        /// <summary>
        /// checks whether room contains an item.
        /// </summary>
        /// <returns>true</returns> if item is present; otherwise, <c>false</c>.</returns>
        public bool HasItem()
        {
            return item != null;
        }
    }
}