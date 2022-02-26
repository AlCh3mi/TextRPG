using System;

namespace ConsoleApplication1.Characters
{
    internal class ChooseClass
    {
        public Character CharacterSelect(int playerNumber, string playerName)
        {
            Console.Write($"Player {playerNumber}, choose your class!\n1. Warrior 2.Priest 3.Mage ");
            var choice = Convert.ToInt32(Console.ReadLine());

            //ToDo: the same for Priest. Change their constructor to have the default values for this class. See Mage/Warrior class
            switch (choice)
            {
                case 1:
                    return new Warrior(playerName);
                case 2:
                    throw new NotImplementedException("Marcus hasn't set up the priest class yet-");
                case 3:
                    return new Mage(playerName);
                default:
                    throw new Exception("Error 404: Character not found");
            }
        }
    }
}
