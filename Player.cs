using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; }


        public Player(string name, int health) : base(name, health)
        {
            Inventory = new Inventory();
        }

        public override void Attack(Creature target)
        {
            var weapons = Inventory.GetWeapons().ToList();

            if (weapons.Count == 0)
            {
                Console.WriteLine(" You have no available weapons to attack with!");
                return;
            }

            Console.WriteLine("Choose a weapon to attack with:");
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {weapons[i].Name} (Damage: {weapons[i].Damage})");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice >= 1 && choice <= weapons.Count)
            {
                var weapon = weapons[choice - 1];
                Console.WriteLine($"{Name} Attacked With {weapon.Name}!");
                target.TakeDamage(weapon.Damage);
            }
            else
            {
                Console.WriteLine("Invalid Choice Try Again");
            }
        }

        public void Heal(int amount)
        {
            if (amount > 0)
            {
                Health += amount;
                Console.WriteLine($"{Name} healed by {amount}. Current health; {Health}");
            }
        }
    }
}
