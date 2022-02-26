using System;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    public class Priest : Character
    {
        public Priest(string name) :
            base(name, ClassType.Priest, 80, 8, 3, 0)

        {
            
        }

        public override void PlayerTurn(Character enemy)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Heal");
            
            Console.Write("What would you like to do: ");
            
            var input = Program.GetInput(1, 3);

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
                    CastSpell(this, new Heal(7));
                    break;
                default:
                    Console.WriteLine("Something went wrong, this should not have happened");
                    break;
            }
        }
    }
}