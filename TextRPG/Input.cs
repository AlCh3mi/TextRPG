using System;
using System.Text;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1
{
    internal static class Input
    {
        public static Character CharacterSelect(int playerNumber)
        {
            Console.Write($"Player {playerNumber}, please enter your name : ");
            var name = Console.ReadLine();
            
            Console.WriteLine();
            Console.WriteLine($"Player {playerNumber}, choose your class!");
            Console.WriteLine();
            
            var sb = new StringBuilder();
            sb.AppendLine("1. Warrior");
            sb.AppendLine("2. Priest");
            sb.AppendLine("3. Mage");

            Console.WriteLine(sb.ToString());
            
            var choice = GetInput();

            switch (choice)
            {
                case 1:
                    return new Warrior(name);
                case 2:
                    return new Priest(name);
                case 3:
                    return new Mage(name);
                default:
                    throw new Exception("Error 404: Character not found");
            }
        }
        
        public static int GetInput(int min = 1, int max = 3)
        {
            Console.Write($"Input: ({min} - {max}): ");

            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (int.TryParse(input.ToString(), out var result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;
                    }

                    Console.WriteLine($"You need to input a valid selection between {min} and {max}.");
                    continue;
                }
                Console.WriteLine("Invalid key. Select a number, please.");
            }
        }
        
        public static Character ChooseTarget(Character caster, Character opponent)
        {
            //this could be adapted to take an array/list
            //of Characters and handle for more than only 2 options
            
            Console.WriteLine("Select Target");
            Console.WriteLine($"1. {caster.Name}");
            Console.WriteLine($"2. {opponent.Name}");
            var input = GetInput(1, 2) - 1;
            return input == 0 ? caster : opponent;
        }
    }
}
