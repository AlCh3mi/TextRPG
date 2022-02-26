using System;
using System.Collections.Generic;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1
{
    public class SpellSelection
    {
        public Spell ChooseSpell(List<Spell> spells)
        {
            for (var i = 0; i < spells.Count; i++)
            {
                Console.WriteLine($"{i+1}. {spells[i]}");
            }

            var input = Program.GetInput(1, spells.Count) - 1;

            return spells[input];
        }
    }
}

//0. Consecrate
//1. Fireball
//2. HolyNova