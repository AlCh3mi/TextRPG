using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    
    public class Fireball : Spell
    {
        public override string Name => "Fireball";
        public override int ManaCost => 6;

        public override void CastSpell(Character caster, Character target)
        {
            var damage = Value + caster.SpellPower;
            Console.WriteLine($"{caster} casts {Name} at {target}");
            target.TakeDamage(damage);
            Console.WriteLine("You can feel the smell of burnt ass hair cling to your nose!");
        }

        public Fireball(int value) : base(value) { }
    }
}