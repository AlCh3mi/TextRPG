using System;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    public abstract class Character
    {
        public string Name;
        
        public ClassType ClassType;
        
        public Health Health;
        
        public int Damage { get; protected set; }

        protected int _defense;
        public virtual int Defense
        {
            get => _defense; 
            protected set => _defense = GameMath.Clamp(value, -10, 10);
        }

        public virtual int SpellPower { get; protected set; } = 1;
        
        public int Mana { get; protected set; }

        public SpellBook SpellBook { get; protected set; }
        
        public bool IsDead => Health.IsDead;

        public virtual void TakeDamage(int damage)
        {
            damage = damage - Defense;
            Health.TakeDamage(damage);
        }

        public virtual void DealDamage(Character enemy)
        {
            enemy.TakeDamage(Damage);
        }

        public virtual void CastSpell(Character target, Spell spell)
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

        public virtual void ArmourModification(int armour)
        {
            Defense += armour;
            Console.WriteLine($"{Name}'s armour has been modified by {armour}");
        }

        public virtual void Heal(int healAmount)
        {
            var healing = healAmount + SpellPower;
            Health.Heal(healing);
            Console.WriteLine($"{Name} heals for {healing} health");
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
                    DealDamage(attackTarget);
                    Console.WriteLine($"{Name} attacks {enemy.Name}");
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