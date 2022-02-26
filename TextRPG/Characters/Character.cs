using System;
using ConsoleApplication1.Spells;

namespace ConsoleApplication1.Characters
{
    public abstract class Character
    {
        public string Name;
        
        public ClassType ClassType;
        
        public Health Health;
        
        public int Damage { get; private set; } = 10;
        
        public int Defense { get; private set; } = 0;
        
        public int SpellPower { get; private set; } = 1;

        public bool IsDead => Health.IsDead;

        public Character(string name, ClassType classType,int maxHealth, int damage, int spellPower, int defense)
        {
            Name = name;
            ClassType = classType;
            Health = new Health(maxHealth);
            Damage = damage;
            SpellPower = spellPower;
            Defense = defense;
        }

        public virtual void TakeDamage(int damage)
        {
            damage = damage - Defense;
            Health.TakeDamage(damage);
        }

        public void DealDamage(Character enemy)
        {
            enemy.TakeDamage(Damage);
        }

        public void CastSpell(Character target, Spell spell)
        {
            spell.CastSpell(this, target);
        }

        public void ArmourModification(int armour)
        {
            Defense += armour;
            Console.WriteLine($"{Name}'s armour has been modified by {armour}");
        }

        public void Heal(int healAmount)
        {
            var healing = healAmount + SpellPower;
            Health.Heal(healing);
            Console.WriteLine($"{Name} heals for {healing} health");
        }

        public abstract void PlayerTurn(Character enemy);
        
        public void ShowStats()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"Health  : {Health.CurrentHealth}/{Health.MaxHealth}");
            Console.WriteLine($"Damage  : {Damage}, SpellPower : {SpellPower}");
            Console.WriteLine($"Defense : {Defense}");
        }
    }
}