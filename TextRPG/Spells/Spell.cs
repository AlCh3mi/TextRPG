using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public abstract class Spell
    {
        public abstract string Name { get; }
        protected int Value { get; set; }
        public abstract int ManaCost { get; }

        protected Spell(int value)
        {
            Value = value;
        }

        public abstract void CastSpell(Character caster, Character target);

        public override string ToString() => $"{Name} ({ManaCost} Mana)";
    }
}