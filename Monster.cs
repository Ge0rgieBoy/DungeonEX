using System;

namespace DungeonExplorer
{
	public class Monster : Creature 
	{
		public int AttackDamage { get; private set; }

		public Monster(string name, int health, int attackDamage) 
			: base(name, health)
		{
			AttackDamage = attackDamage;
		}

		public override void Attack(Creature target)
		{
			Console.WriteLine($"{Name} attacks for {AttackDamage} damage!");
			target.TakeDamage(AttackDamage);
		}
	}
}