using System;
using System.Collections.Generic;
using ConsoleApplication1.Characters;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1
{
    public class SpellBook
    {
        public List<Spell> Spells;

        private readonly Character Owner;

        private Random random;

        public SpellBook(Character owner, List<Spell> spells)
        {
            this.Owner = owner;
            this.Spells = spells;
            random = new Random();
        }
        
        public bool CanAffordAnySpell()
        {
            foreach (var spell in Spells)
            {
                if (Owner.Mana >= spell.ManaCost)
                    return true;
            }

            return false;
        }
        
        public Spell ChooseSpell()
        {
            if (!CanAffordAnySpell())
            {
                Console.WriteLine("Not enough Mana to cast any of your spells");
                return null;
            }
            
            Console.WriteLine("Choose a spell");
            var input = 0;
            SpellSelectionMenu();
           
            do
            {
                input = Input.GetInput(1, Spells.Count) - 1;
                if(Spells[input].ManaCost > Owner.Mana)
                    Console.WriteLine($"Not enough Mana to cast {Spells[input].Name}");
            } 
            while (Spells[input].ManaCost > Owner.Mana);
            
            return Spells[input];
        }
        
        private void SpellSelectionMenu()
        {
            for (int i = 0; i < Spells.Count; i++)
            {
                Console.WriteLine($"{i+1}. {Spells[i].Name}({Spells[i].ManaCost} mana)");
            }
        }

        ///returns a value between 1 and the Spell Power of the owner of this SpellBook
        public int SpellRng()
        {
            return random.Next(1, Owner.SpellPower);
        }
    }
}