using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Heal : Spell
    {
        public override string Name => "Heal";
        public override int ManaCost => 5;
        
        public Heal(int value) : base(value) { }

        public override void CastSpell(Character caster, Character target)
        {
            var healing = Value + caster.SpellPower;
            Console.WriteLine($"{caster} casts {Name} on {target}");
            target.Heal(healing);
        }
    }
}