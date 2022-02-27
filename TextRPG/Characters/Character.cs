using System;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    public abstract class Character
    {
        public string Name;

        public ClassType ClassType;

        #region Health

        public Health Health;

        public virtual void Heal(int healAmount)
        {
            Health.Heal(healAmount);
            Console.WriteLine($"{Name} heals for {healAmount} health");
        }

        public virtual void TakeDamage(int damage)
        {
            damage = damage - Defense;
            Health.TakeDamage(damage);
            Console.WriteLine($"{Name} took {damage} Damage");
        }

        public virtual void TrueDamage(int trueDamage)
        {
            Health.TakeDamage(trueDamage);
            Console.WriteLine($"{Name} took {trueDamage} True Damage (Armour was ignored)");
        }

        public bool IsDead => Health.IsDead;

        #endregion

        #region Defense

        protected int _defense;

        public virtual int Defense
        {
            get => _defense;
            protected set => _defense = GameMath.Clamp(value, -10, 10);
        }

        public virtual void ArmourModification(int armour)
        {
            Defense += armour;

            Console.WriteLine(armour > 0
                ? $"{Name}'s armour has been increased by {armour}"
                : $"{Name}'s armour has been reduced by {armour}");
        }

        #endregion

        #region Damage

        public int Damage { get; protected set; }

        public virtual void DamageModify(int damage) => Damage += damage;

        public virtual void DealDamage(Character enemy) => enemy.TakeDamage(Damage);

        #endregion

        #region Magic
        
        public int Mana { get; protected set; }
        public virtual void ManaModify(int mana) => Mana += mana;

        protected int _spellPower = 1;

        public virtual int SpellPower
        {
            get => _spellPower;
            protected set => _spellPower = value;
        }

        public virtual void SpellPowerModify(int spellPwr)
        {
            SpellPower += spellPwr;
            Console.WriteLine($"{this}'s Spell Power was modified by {spellPwr}");
        }
        
        #endregion
        
        public SpellBook SpellBook { get; protected set; }
        protected virtual void CastSpell(Character target, Spell spell)
        {
            if (spell == null)
                return;

            if (spell.ManaCost > Mana)
            {
                Console.WriteLine($"Not enough mana to cast {spell.Name}");
                return;
            }

            Mana -= spell.ManaCost;
            spell.CastSpell(this, target);
        }

        public void PlayerTurn(Character enemy)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Cast Spell");
            Console.WriteLine();
            Console.Write("What would you like to do: ");

            var input = Input.GetInput(1, 3);

            switch (input)
            {
                case 1:
                    var attackTarget = Input.ChooseTarget(this, enemy);
                    Console.WriteLine($"{Name} attacks {enemy.Name}");
                    DealDamage(attackTarget);
                    break;
                case 2:
                    ArmourModification(1);
                    break;
                case 3:
                    if (!SpellBook.CanAffordAnySpell())
                    {
                        Console.WriteLine("Not enough mana to cast any spells.");
                        PlayerTurn(enemy);
                        break;
                    }

                    var spell = SpellBook.ChooseSpell();
                    var spellTarget = Input.ChooseTarget(this, enemy);
                    CastSpell(spellTarget, spell);
                    break;
                default:
                    throw new Exception("Invalid Character Action.");
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name} ({ClassType})");
            Console.WriteLine($"Health    : {Health.CurrentHealth}/{Health.MaxHealth}");
            Console.WriteLine($"Mana      : {Mana}");
            Console.WriteLine($"SpellPower: {SpellPower}");
            Console.WriteLine($"Damage    : {Damage}, ");
            Console.WriteLine($"Defense   : {Defense}");
        }

        public override string ToString() => Name;
    }
}