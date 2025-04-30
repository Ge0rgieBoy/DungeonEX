using System;

namespace DungeonExplorer
{
	public interface IDamageable
	{
		void TakeDamage(int amount);
	}

	public interface ICollectible
	{
		string Name { get; }
	}
}
