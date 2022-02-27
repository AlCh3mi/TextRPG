using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class DrumsOfWar : Spell
    {
        public DrumsOfWar(int value) : base(value) { }

        public override string Name => "Drums of War";
        public override int ManaCost => 2;
        public override void CastSpell(Character caster, Character target)
        {
            Console.WriteLine($"Heightened eagerness for Combat! Damage and Spell Power increased by {Value}");
            target.DamageModify(Value);
            target.SpellPowerModify(Value);
        }
    }
}