using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Meteor Damage is multiplied by SpellPower
    /// </summary>
    public class Meteor : Spell
    {
        public Meteor(int value) : base(value) { }
        
        public override string Name => "Meteor";
        public override int ManaCost => 10;

        public override void CastSpell(Character caster, Character target)
        {
            var damage = Value * caster.SpellPower;
            Console.WriteLine($"{Name} damages {target.Name} for {damage} damage");
            target.TakeDamage(damage);
        }
    }
}