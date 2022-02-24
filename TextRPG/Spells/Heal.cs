using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Heal : Spell
    {
        public Heal(int value)
        {
            Value = value;
        }
        
        public override void CastSpell(Character caster, Character target)
        {
            target.Heal(Value + caster.SpellPower);
        }
    }
}