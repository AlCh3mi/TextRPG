using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main()
        {
            var warrior = new Character("Warrior", ClassType.Warrior, 100, 10, 1, 0);
            var priest = new Character("Priest", ClassType.Priest, 80, 8, 3, 0);
            
            var turnCounter = 0;
            while (true)
            {
                turnCounter++;
                Console.Clear();
                Console.WriteLine("Turn #" +turnCounter);
                ShowStats(warrior);
                PlayerTurn(warrior, priest);
                if (warrior.IsDead || priest.IsDead)
                    break;
                ShowStats(priest);
                PlayerTurn(priest, warrior);
                if (warrior.IsDead || priest.IsDead)
                    break;
            
                Console.WriteLine("Turn completed, press any key to continue");
                Console.ReadKey();
            }

            int x = 5;
            int y = 2;
            float z = -1;
            double d = 0.2345;
            var answer = GameMath.Clamp(d, -1, 0.2);
            Console.WriteLine(answer);
        }

        public static void PlayerTurn(Character actingPlayer, Character enemy)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Cast Spell");
                
            if(actingPlayer.ClassType == ClassType.Priest)
                Console.WriteLine("4. Heal");
            
            Console.Write("What would you like to do: ");
            
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    actingPlayer.DealDamage(enemy);
                    Console.WriteLine($"{actingPlayer.Name} attacks {enemy.Name}");
                    break;
                case 2:
                    actingPlayer.ArmourBuff(1);
                    break;
                case 3:
                    if(actingPlayer.ClassType == ClassType.Warrior)
                    {
                        Console.WriteLine("Warrior casts double axe throw");
                        actingPlayer.CastSpell(enemy, 1);
                        actingPlayer.CastSpell(enemy, 1);
                    }
                    else if(actingPlayer.ClassType == ClassType.Priest)
                    {
                        Console.WriteLine("Priest casts Consecrate");
                        actingPlayer.CastSpell(enemy, 3);
                    }
                    break;
                case 4:
                    if(actingPlayer.ClassType != ClassType.Priest)
                        break;
                    actingPlayer.Heal(5);
                    
                    break;
                default:
                    Console.WriteLine("erm....");
                    break;
            }
        }

        public static void ShowStats(Character character)
        {
            Console.WriteLine(character.Name);
            Console.WriteLine($"Health  : {character.CurrentHealth}/{character.MaxHealth}");
            Console.WriteLine($"Damage  : {character.Damage}, SpellPower : {character.SpellPower}");
            Console.WriteLine($"Defense : {character.Defense}");
        }
    }
}