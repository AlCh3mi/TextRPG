using ConsoleApplication1.Characters;

namespace ConsoleApplication1.Spells
{
    public class Rend : Spell
    {
        public override string Name => "Rend";
        public override int ManaCost => 4;

        public override void CastSpell(Character caster, Character target)
        {
            target.ArmourModification(-Value);
            target.TakeDamage(Value);
        }

        public Rend(int value) : base(value)
        {
        }
    }
}