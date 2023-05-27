using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace DefaultNamespace
{
    public class Enemy : Entity
    {
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private Color damageColor;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
            damageColor = Color.red;
            CurrentHealth = MaxHealth;
        }
        
        public UnityEvent healthBarChanged;

        public override void Die()
        {
            // Play kill animation
            Spawner?.NotifyDead();
            Destroy(gameObject);
        }

        public override void TakeDamage(float damage)
        {
            healthBarChanged?.Invoke();
            StartCoroutine(DamageAnimation());
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
                Die();
        }

        public override void Heal(float points)
        {
            healthBarChanged?.Invoke();
            CurrentHealth += points;
        }

        private IEnumerator DamageAnimation()
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = originalColor;
        }
    }
}