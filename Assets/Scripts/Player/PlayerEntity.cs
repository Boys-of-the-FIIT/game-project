using System;
using Bullet;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Player
{
    public class PlayerEntity : MonoBehaviour, IEntity
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float health;
        
        public float MaxHealth
        {
            get => maxHealth;
            private set => maxHealth = value;
        }
        
        public float Health
        {
            get => health;
            private set => health = value;
        }
        
        public UnityEvent healthBarChanged;
        
        public void Die()
        {
            // Show game over screen
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            healthBarChanged?.Invoke();
            Health -= damage;
            if (health <= 0)
                Die();
        }

        public void Heal(int points)
        {
            healthBarChanged?.Invoke();
            Health += points;
        }
    }
}