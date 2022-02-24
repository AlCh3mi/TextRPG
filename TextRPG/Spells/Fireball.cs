using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Fireball : Spell
    {
        public Fireball(int value = 6)
        {
            Value = value;
        }
        
        public override void CastSpell(Character caster, Character target)
        {
            target.TakeDamage(Value + caster.SpellPower);
        }
    }
}