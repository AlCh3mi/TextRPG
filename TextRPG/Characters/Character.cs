using System;

namespace ConsoleApplication1.Characters
{
    public class Character
    {
        public int MaxHealth = 100;

        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                
                if (_currentHealth < 0)
                    _currentHealth = 0;

                if (_currentHealth > MaxHealth)
                    _currentHealth = MaxHealth;
            }
        }

        public int Damage = 10;
        public int SpellPower = 1;
        public int Defense = 0;
        public ClassType ClassType;
        public string Name;

        public bool IsDead => CurrentHealth <= 0;

        public void TakeDamage(int damage)
        {
            damage = damage - Defense;
            
            if (damage <= 0)
                return;
            
            CurrentHealth -= damage;
        }

        public void DealDamage(Character enemy)
        {
            enemy.TakeDamage(Damage);
        }

        public void CastSpell(Character enemy, int Spell)
        {
            enemy.TakeDamage(Spell * SpellPower);
        }

        public void ArmourBuff(int armour)
        {
            Defense += armour;
            Console.WriteLine($"{Name} reinforced his armour by {armour}");
        }

        public void Heal(int healAmount)
        {
            CurrentHealth += healAmount + SpellPower;
            Console.WriteLine($"{Name} heals for {healAmount + SpellPower} health");
        }

        public Character(string name, ClassType classType,int maxHealth, int damage, int spellPower, int defense)
        {
            Name = name;
            ClassType = classType;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Damage = damage;
            SpellPower = spellPower;
            Defense = defense;
        }
    }
}