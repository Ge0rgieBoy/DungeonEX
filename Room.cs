namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;

        public Room(string description, string item)
        {
            this.description = description;
            this.item = item;
        }

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

        public bool HasItem()
        {
            return item != null;
        }
    }
}