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
                warrior.ShowStats();
                warrior.PlayerTurn(priest);
                if (warrior.IsDead || priest.IsDead)
                    break;
                priest.ShowStats();
                priest.PlayerTurn(warrior);
                if (warrior.IsDead || priest.IsDead)
                    break;
            
                Console.WriteLine("Turn completed, press any key to continue");
                Console.ReadKey();
            }
        }
    }
}