using System.Collections.Generic;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    /// <summary>
    /// Passive: If Mage has less than 50% health, SpellPower is doubled!
    /// </summary>
    public sealed class Mage : Character
    {
        public Mage(string name)
        {
            Name = name;
            ClassType = ClassType.Mage;
            Health = new Health(75);
            Damage = 5;
            SpellPower = 5;
            Defense = 0;
            Mana = 25;
            SpellBook = new SpellBook(this, new List<Spell>
            {
                new Fireball(4),
                new Meteor(5),
                new GiftOfMana(10),
                new ManaBurn(0),
                new Blizzard(3)
            });
            
        }

        public override int SpellPower
        {
            get
            {
                if (Health.CurrentHealth > Health.MaxHealth / 2) 
                    return _spellPower;
                
                return _spellPower * 2;

            }
            protected set => _spellPower = value;
        }
    }
}