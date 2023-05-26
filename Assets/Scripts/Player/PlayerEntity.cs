using System;
using Bullet;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Player
{
    public class PlayerEntity : Entity
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float health;
        
        public override float MaxHealth => maxHealth;
        public override float Health => health;

        public UnityEvent healthBarChanged;
        
        public override void Die()
        {
            // Show game over screen
            Destroy(gameObject);
        }

        public override void TakeDamage(int damage)
        {
            healthBarChanged?.Invoke();
            health -= damage;
            if (health <= 0)
                Die();
        }

        public override void Heal(int points)
        {
            healthBarChanged?.Invoke();
            health += points;
        }
    }
}