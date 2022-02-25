using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main()
        {
            var warrior = new Warrior("Warrior", ClassType.Warrior, 100, 10, 1, 0);
            var priest = new Priest("Priest", ClassType.Priest, 80, 8, 3, 0);
            var mage = new Mage("Mage", ClassType.Mage, 90, 3, 5, 0);

            //Start with a character choosing thingiemajig.
            //Didn't have time to get any further though
            var player1 = ChooseClass.ChoosePlayer(1);
            var player2 = ChooseClass.ChoosePlayer(2);

            
            var turnCounter = 0;
            while (true)
            {
                turnCounter++;
                Console.Clear();
                Console.WriteLine("Turn #" +turnCounter);
                
                //Player1 Turn
                warrior.ShowStats();
                warrior.PlayerTurn(priest);
                if (warrior.IsDead || priest.IsDead)
                    break;
                
                //Player2 Turn
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