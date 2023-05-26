using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Entity : MonoBehaviour
    {
        public abstract float Health { get; }
        public abstract float MaxHealth { get;  }
        public abstract void Die();
        public abstract void TakeDamage(int damage);
        public abstract void Heal(int points);
    }
}