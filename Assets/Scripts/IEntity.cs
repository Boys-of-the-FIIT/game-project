namespace DefaultNamespace
{
    public abstract class Entity
    {
        public int Health;
        public abstract void Die();
        public abstract void TakeDamage(int damage);
    }
}