using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Heal : Spell
    {
        public int Level = 1;
        
        public Heal(int value, int level = 1)
        {
            Level = level;
            Value = value;
        }
        
        public override void CastSpell(Character caster, Character target)
        {
            target.Heal(Value + (caster.SpellPower * Level));
        }
    }
}