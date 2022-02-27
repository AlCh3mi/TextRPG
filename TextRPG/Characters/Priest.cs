using System;
using System.Collections.Generic;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    /// <summary>
    /// Priest gains Mana when damage is taken.
    /// </summary>
    public class Priest : Character
    {
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
                new Fireball(3)
            });
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            if (IsDead) 
                return;
            
            Mana++;
            Console.WriteLine($"{Name} gained 1 mana from passive");
        }
    }
}