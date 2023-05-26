using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public abstract class Entity : MonoBehaviour
    {
        public abstract float Health { get; }
        public abstract float MaxHealth { get; }
        public abstract void Die();
        public abstract void TakeDamage(float damage);
        public abstract void Heal(float points);
    }
}