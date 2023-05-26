using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Player
{
    public class PlayerEntity : Entity
    {
        [SerializeField] private float maxHealth;
        public override float MaxHealth => maxHealth;
        public override float Health => currentHealth;
        
        private float currentHealth;
        public UnityEvent healthBarChanged;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public override void Die()
        {
            // Show game over screen
            Destroy(gameObject);
        }

        public override void TakeDamage(float damage)
        {
            healthBarChanged?.Invoke();
            currentHealth -= damage;
            if (currentHealth <= 0)
                Die();
        }

        public override void Heal(float points)
        {
            healthBarChanged?.Invoke();
            currentHealth += points;
        }
    }
}