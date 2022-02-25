using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Characters
{
    internal class ChooseClass
    {

        public static string ChoosePlayer(int player)
        {
            Console.Write($"Player {player}, choose your class!\n1. Warrior 2.Priest 3.Mage ");
            var choice = Convert.ToInt32(Console.ReadLine());
            var whatClass = string.Empty;

            if (choice == 1)
                whatClass = "warrior";
            else if (choice == 2)
                whatClass = "priest";
            else if (choice == 3)
                whatClass = "mage";

            return whatClass;
        }
    }
}
