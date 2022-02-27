using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Heal : Spell
    {
        public override string Name => "Heal";
        public override int ManaCost => 5;
        
        public Heal(int value, int level = 1) : base(value)
        {
            Value = value;
        }

        public override void CastSpell(Character caster, Character target)
        {
            target.Heal(Value + (caster.SpellPower));
        }
    }
}