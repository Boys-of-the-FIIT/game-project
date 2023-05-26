using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace DefaultNamespace
{
    public class Enemy : Entity
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private Spawner parentSpawner;
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private Color damageColor;

        public override float MaxHealth => maxHealth;
        public override float Health => health;
        

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
            damageColor = Color.red;
        }
        
        public UnityEvent healthBarChanged = new ();

        public override void Die()
        {
            // Play kill animation
            parentSpawner?.NotifyDead(this);
            Destroy(gameObject);
        }

        public override void TakeDamage(int damage)
        {
            healthBarChanged?.Invoke();
            StartCoroutine(DamageAnimation());
            health -= damage;
            if (Health <= 0)
                Die();
        }

        public override void Heal(int points)
        {
            healthBarChanged?.Invoke();
            health += points;
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