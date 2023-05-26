using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour, IEntity
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private Spawner parentSpawner;
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private Color damageColor;

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

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
            damageColor = Color.red;
        }
        
        public UnityEvent healthBarChanged = new ();

        public void Die()
        {
            // Play kill animation
            parentSpawner?.NotifyDead(this);
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            healthBarChanged?.Invoke();
            StartCoroutine(DamageAnimation());
            Health -= damage;
            if (Health <= 0)
                Die();
        }

        public void Heal(int points)
        {
            throw new NotImplementedException();
        }

        public void AttachToSpawner(Spawner spawner)
        {
            parentSpawner = spawner;
        }

        private IEnumerator DamageAnimation()
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = originalColor;
        }
    }
}