using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Instances of Damage: Value
    /// Damage: TrueDMG : 1 + Spell Power
    /// </summary>
    public class Whirlwind : Spell
    {
        public Whirlwind(int value) : base(value) { }

        public override string Name => "Whirlwind";
        public override int ManaCost => 3;
        public override void CastSpell(Character caster, Character target)
        {
            Console.WriteLine($"{caster} casts {Name}");
            
            for (int i = 0; i < Value; i++)
            {
                var damage = 1 + caster.SpellPower;
                target.TrueDamage(damage);
            }
        }
    }
}