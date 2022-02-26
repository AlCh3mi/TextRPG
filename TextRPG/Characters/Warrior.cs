using System;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name) : 
            base(name, ClassType.Warrior, 100, 10, 1, 3)
        {
            //This is the default stats for a warrior now.
            //If we want the ability to change its starting stats,
            //then we should create another constructor for that.
            
            //ToDo: do the same for Priest.
        }
        
        public override void PlayerTurn(Character enemy)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Rend");
            
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
                    CastSpell(enemy, new Rend(2));
                    break;
                default:
                    Console.WriteLine("Something went wrong, this should not have happened");
                    break;
            }
        }
        
        
    }
}