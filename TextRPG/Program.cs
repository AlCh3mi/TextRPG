using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static Character player1;
        public static Character player2;

        public static bool GameOver => player1.IsDead || player2.IsDead;

        public static void Main()
        {
            
            var chooseClass = new ChooseClass(); 

            player1 = chooseClass.CharacterSelect(1);
            player2 = chooseClass.CharacterSelect(2);
           
            var turnCounter = 0;

            while (!GameOver)
            {
                turnCounter++;
                Console.Clear();
                Console.WriteLine("Turn #" + turnCounter);

                PlayerTurn(player1, player2);
                if (GameOver)
                    break;

                PlayerTurn(player2, player1);
                if (GameOver)
                    break;

                Console.WriteLine("Turn completed, press any key to continue");
                Console.ReadKey();
            }
        }

        private static void PlayerTurn(Character actingPlayer, Character enemyPlayer)
        {
            
            actingPlayer.ShowStats();
            actingPlayer.PlayerTurn(enemyPlayer);
        }
        public static int GetInput(int min = 1, int max = 3)
        {
            Console.Write($"(Enter a number between {min} and {max}): ");

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

                    Console.WriteLine("You need to input a valid selection.");
                    continue;
                }
                Console.WriteLine("Invalid key. Select a number, please.");
            }

        }
    }
}