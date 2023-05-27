using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Player
{
    public class PlayerEntity : Entity
    {
        public UnityEvent healthBarChanged;

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public override void Die()
        {
            // Show game over screen
            Destroy(gameObject);
        }

        public override void TakeDamage(float damage)
        {
            healthBarChanged?.Invoke();
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
                Die();
        }

        public override void Heal(float points)
        {
            healthBarChanged?.Invoke();
            CurrentHealth += points;
        }
    }
}