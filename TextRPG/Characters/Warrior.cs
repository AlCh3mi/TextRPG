using System;
using System.Collections.Generic;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    /// <summary>
    /// Warrior has LAST STAND(avoids death 1 time)
    /// his armour cannot be reduced below {minArmour}
    /// Gains twice as much Armour
    /// </summary>
    public sealed class Warrior : Character
    {
        private bool LastStandTriggered { get; set; }
        private int minArmour = 3;
        private int maxArmour = 15;
        
        public Warrior(string name) 
        {
            Name = name;
            ClassType = ClassType.Warrior;
            Health = new Health(100);
            Damage = 10;
            SpellPower = 1;
            Defense = minArmour;
            Mana = 12;
            SpellBook = new SpellBook(this, new List<Spell>()
            {
                new Rend(2),
                new Whirlwind(5),
                new DrumsOfWar(1)
            });
        }

        public override int Defense
        {
            get => _defense; 
            protected set => _defense = GameMath.Clamp(value, minArmour, maxArmour);
        }

        public override void ArmourModification(int armour)
        {
            if(armour > 0)
            {
                base.ArmourModification(armour * 2);
                return;
            }

            base.ArmourModification(-armour);
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
            base.TakeDamage(damage);
        }
    }
}