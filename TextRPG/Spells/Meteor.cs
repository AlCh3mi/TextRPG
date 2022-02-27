using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Meteor : Spell
    {
        public override string Name => "Meteor";
        public override int ManaCost => 10;

        public override void CastSpell(Character caster, Character target)
        {
            var damage = Value + (target.Health.CurrentHealth / 4) + caster.SpellPower;
            target.TakeDamage(damage);
            Console.WriteLine($"Meteor damages {target.Name} for {damage} damage");
        }

        public Meteor(int value) : base(value)
        {
            
        }
    }
}