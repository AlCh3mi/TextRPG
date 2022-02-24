namespace ConsoleApplication1
{
    public class Health
    {
        public int MaxHealth { get; private set; }
        
        public int CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = GameMath.Clamp(value, 0, MaxHealth);
        }
        
        private int _currentHealth;

        public void SetMaxHealth(int maxHealth)
        {
            MaxHealth = maxHealth;
            
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                return;
            
            CurrentHealth -= damage;
        }

        public void Heal(int healing)
        {
            if (healing <= 0)
                return;

            CurrentHealth += healing;
        }

        public bool IsDead => CurrentHealth <= 0;

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
    }
}