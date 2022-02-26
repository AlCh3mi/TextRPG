using System;
using System.Text;

namespace ConsoleApplication1.Characters
{
    internal class ChooseClass
    {
        public Character CharacterSelect(int playerNumber)
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
            

            var choice = Program.GetInput();

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
    }
}
