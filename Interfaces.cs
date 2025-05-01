using System;

namespace DungeonExplorer
{
	public interface IDamageable
	{
		void TakeDamage(int amount);
	}

	public interface ICollectable
	{
		string Name { get; }
		void Use(Player player);
	}
}
