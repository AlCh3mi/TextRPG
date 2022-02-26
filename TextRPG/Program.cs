using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main()
        {
            //do you see how player1 and player2's Character creation are almost the same?
            //and player turn are almost identical code too, we are repeating ourselves
            //DRY - Dont Repeat Yourself
            //todo: How can we improve this?
            
            var chooseClass = new ChooseClass(); //create a new instance of the ChooseClass class. 
            
            Console.WriteLine("Player 1, please enter your name : ");
            var p1Name = Console.ReadLine();
            var player1 = chooseClass.CharacterSelect(1, p1Name); //Use the instance of ChooseClass to return a character to use with the correct type.
            
            Console.Clear();
            Console.WriteLine("Player 2, please enter your name : ");
            var p2Name = Console.ReadLine();
            var player2 = chooseClass.CharacterSelect(2, p2Name);

            var turnCounter = 0;
            while (true)
            {
                turnCounter++;
                Console.Clear();
                Console.WriteLine("Turn #" +turnCounter);
                
                //Player1 Turn
                player1.ShowStats();
                player1.PlayerTurn(player2);
                if (player1.IsDead || player2.IsDead)
                    break;
                
                //Player2 Turn
                player2.ShowStats();
                player2.PlayerTurn(player1);
                if (player1.IsDead || player2.IsDead)
                    break;
            
                Console.WriteLine("Turn completed, press any key to continue");
                Console.ReadKey();
            }
        }
    }
}