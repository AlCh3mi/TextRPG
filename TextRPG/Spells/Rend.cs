using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Rend : Spell
    {
        public Rend(int value)
        {
            Value = value;
        }
        public override void CastSpell(Character caster, Character target)
        {
            target.ArmourModification(-Value);
            target.TakeDamage(Value);
        }
    }
}