using System;

namespace DungeonExplorer
{
    public  abstract class Creature : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive => Health > 0;

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public abstract void Attack(Creature target);

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage. Health now {Health}");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has fallen!");
            }
        }
    }
}