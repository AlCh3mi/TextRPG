using System;
using System.Collections.Generic;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    /// <summary>
    /// Priest gains Mana when damage is taken.
    /// </summary>
    public sealed class Priest : Character
    {
        private int manaGain = 1;
        public Priest(string name)
        {
            Name = name;
            ClassType = ClassType.Priest;
            Health = new Health(80);
            Damage = 8;
            SpellPower = 3;
            Defense = 1;
            Mana = 20;
            SpellBook = new SpellBook(this, new List<Spell>()
            {
                new Heal(10),
                new Judgement(8),
                new Smite(0)
            });
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            if (IsDead) 
                return;
            
            Mana += manaGain;
            Console.WriteLine($"{Name} gained {manaGain} mana from passive");
        }
    }
}