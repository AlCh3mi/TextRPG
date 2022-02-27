using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public abstract class Spell
    {
        public abstract string Name { get; }
        public int Value { get; protected set; }
        public abstract int ManaCost { get; }
        
        public Spell(int value)
        {
            Value = value;
        }

        public abstract void CastSpell(Character caster, Character target);
    }
}