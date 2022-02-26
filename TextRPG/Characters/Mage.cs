using System;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    public class Mage : Character
    {
        public Mage(string name) : 
            base(name, ClassType.Mage, 75, 5, 5, 0)
        {
            //This is the default stats for a mage now.
            //If we want the ability to change its starting stats,
            //then we should create another constructor for that.
            
            //ToDo: do the same for Priest.
        }
        
        public override void PlayerTurn(Character enemy)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Cast Fireball");

            Console.Write("What would you like to do: ");

            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    DealDamage(enemy);
                    Console.WriteLine($"{Name} attacks {enemy.Name}");
                    break;
                case 2:
                    ArmourModification(1);
                    break;
                case 3:
                    CastSpell(this, new Fireball());
                    Console.WriteLine("You can feel the smell of burnt ass hair cling to your nose!");
                    break;
                default:
                    Console.WriteLine("Something went wrong, this should not have happened");
                    break;
            }
        }
    }
}
