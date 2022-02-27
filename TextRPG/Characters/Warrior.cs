using System;
using System.Collections.Generic;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    /// <summary>
    /// Warrior avoids death 1 time, and his armour cannot be reduced below 0
    /// </summary>
    public sealed class Warrior : Character
    {
        private bool LastStandTriggered { get; set; }
        
        public Warrior(string name) 
        {
            Name = name;
            ClassType = ClassType.Warrior;
            Health = new Health(100);
            Damage = 10;
            SpellPower = 1;
            Defense = 3;
            Mana = 10;
            SpellBook = new SpellBook(this, new List<Spell>()
            {
                new Rend(4),
            });
        }

        public override int Defense
        {
            get => _defense; 
            protected set => GameMath.Clamp(value, 0, 15);
        }

        public override void TakeDamage(int damage)
        {
            damage = damage - Defense;
            if(damage >= Health.CurrentHealth && !LastStandTriggered)
            {
                Health.TakeDamage(Health.CurrentHealth - 1);
                LastStandTriggered = true;
                Console.WriteLine("Warrior stages his LAST STAND!");
                return;
            }
            Health.TakeDamage(damage);
        }
    }
}