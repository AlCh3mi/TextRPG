using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public abstract class Spell
    {
        public int Value { get; set; }

        public abstract void CastSpell(Character caster, Character target);
    }
}