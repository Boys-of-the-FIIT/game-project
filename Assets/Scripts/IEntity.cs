namespace DefaultNamespace
{
    public interface IEntity
    {
        public float Health { get; }
        public float MaxHealth { get;  }
        public void Die();
        public void TakeDamage(int damage);
        public void Heal(int points);
    }
}