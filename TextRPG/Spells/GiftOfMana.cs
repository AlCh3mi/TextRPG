using System;
using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    /// <summary>
    /// Grants Mana to a target.
    /// </summary>
    public class GiftOfMana : Spell
    {
        public GiftOfMana(int value) : base(value) { }

        public override string Name => "Gift of Mana";
        public override int ManaCost => 0;
        public override void CastSpell(Character caster, Character target)
        {
            var manaToAdd = Value + caster.SpellPower;
            Console.WriteLine($"Surrounding magical energy is channeled towards {target}. Adds {manaToAdd} Mana");
            target.ManaModify(manaToAdd);
        }
    }
}