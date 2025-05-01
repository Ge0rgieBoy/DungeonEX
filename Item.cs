using System;

namespace DungeonExplorer
{
	public abstract class Item : ICollectable
	{
		public string Name { get; protected set; }

		public Item(string name)
		{
			Name = name;
		}

		public abstract void Use(Player player); 
	}
}
