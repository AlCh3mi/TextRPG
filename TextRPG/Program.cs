using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static Character player1;
        private static Character player2;

        public static bool GameOver => player1.IsDead || player2.IsDead;

        public static void Main()
        {
            player1 = Input.CharacterSelect(1);
            player2 = Input.CharacterSelect(2);
           
            var turnCounter = 0;

            while (!GameOver)
            {
                turnCounter++;
                Console.Clear();
                Console.WriteLine("Turn #" + turnCounter);

                PlayerTurn(player1, player2);
                if (GameOver)
                    break;

                Console.WriteLine("End of Turn, press any key to continue..");
                Console.ReadKey();
                
                Console.Clear();
                Console.WriteLine("Turn #" + turnCounter);
                
                PlayerTurn(player2, player1);
                if (GameOver)
                    break;

                Console.WriteLine("End of Turn, press any key to continue..");
                Console.ReadKey();
            }
        }

        private static void PlayerTurn(Character actingPlayer, Character enemyPlayer)
        {
            actingPlayer.ShowStats();
            actingPlayer.PlayerTurn(enemyPlayer);
        }
    }
}