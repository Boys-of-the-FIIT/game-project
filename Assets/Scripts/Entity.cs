using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float _currentCurrentHealth;
        private EntitySpawner _entitySpawner;

        public float CurrentHealth
        {
            get => _currentCurrentHealth;
            private protected set => _currentCurrentHealth = value;
        } 
        
        public float MaxHealth
        {
            get => maxHealth;
            private protected set => _currentCurrentHealth = value;
        } 
        
        public EntitySpawner Spawner
        {
            get => _entitySpawner;
            set => _entitySpawner = value;
        }
        
        public abstract void Die();
        public abstract void TakeDamage(float damage);
        public abstract void Heal(float points);
    }
}