using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Instances of Damage: Random between 1 and Spell Power
    /// Damage: Value + Spell Power
    /// </summary>
    public class Blizzard : Spell
    {
        public Blizzard(int value) : base(value) { }

        public override string Name => "Blizzard";
        public override int ManaCost => 20;
        public override void CastSpell(Character caster, Character target)
        {
            var amountOfShards = caster.SpellBook.SpellRng();
            Console.WriteLine($"{caster} casts Blizzard on {target} and hits with {amountOfShards} shards");
            for (var i = 0; i < amountOfShards; i++)
            {
                target.TakeDamage(Value + caster.SpellPower);
            }
        }
    }
}