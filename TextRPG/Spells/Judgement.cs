using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Damages target, and heals caster
    /// Damage: TrueDmg
    /// </summary>
    public class Judgement : Spell
    {
        public Judgement(int value) : base(value) { }

        public override string Name => "Judgement";
        public override int ManaCost => 15;
        public override void CastSpell(Character caster, Character target)
        {
            Console.WriteLine($"{caster} casts Judgement!");
            target.TrueDamage(Value);
            Console.WriteLine($"{target} takes {Value} True Damage");
            var healing = Value + caster.SpellPower;
            caster.Heal(healing);
            Console.WriteLine($"{caster} recovers {healing} health from {Name}");
        }
    }
}