using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Target takes damage equal to their Mana
    /// </summary>
    public class ManaBurn : Spell
    {
        public ManaBurn(int value) : base(value) { }

        public override string Name => "Mana Burn";
        public override int ManaCost => 15;
        public override void CastSpell(Character caster, Character target)
        {
            target.TakeDamage(target.Mana);
            Console.WriteLine($"{target} takes damage equal to their Mana({target.Mana})");
        }
    }
}