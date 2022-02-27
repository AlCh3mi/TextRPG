namespace ConsoleApplication1
{
    public class Health
    {
        public bool IsDead => CurrentHealth <= 0;
        
        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = GameMath.Clamp(value, 0, MaxHealth);
        }

        public int MaxHealth { get; private set; }

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

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public Health(int currentHealth, int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
    }
}