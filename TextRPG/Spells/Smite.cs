using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Spends all Mana, and deals that much Damage to target
    /// Not affected by Spell Power
    /// </summary>
    public class Smite : Spell
    {
        public Smite(int value) : base(value) { }

        public override string Name => "Smite";
        public override int ManaCost => 0;
        public override void CastSpell(Character caster, Character target)
        {
            var damage = caster.Mana;
            Console.WriteLine($"{caster} spends all his Mana to deal {damage} to himself and {target}");
            caster.TakeDamage(damage);
            target.TakeDamage(damage);
            caster.ManaModify(-damage);
            
        }
    }
}