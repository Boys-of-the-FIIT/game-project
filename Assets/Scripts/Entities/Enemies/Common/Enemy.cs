using System;
using System.Collections;
using System.Linq;
using Bullets;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Enemies
{
    public class Enemy : Entity
    {
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private Color damageColor;

        private void Awake()
        {
            Stats.CurrentHealth = Stats.MaxHealth;
        }

        private void Start()
        {
            spriteRenderer = GetComponentsInChildren<SpriteRenderer>()
                .FirstOrDefault(x => x.name == "Circle");
            originalColor = spriteRenderer.color;
            damageColor = Color.red;
        }

        public override void Die()
        {
            OnEntityDeath?.Invoke(this);
            Destroy(gameObject);
        }

        public override void ApplyDamage(float damage)
        {
            StartCoroutine(DamageAnimation());
            Stats.CurrentHealth -= damage;
            if (Stats.CurrentHealth > 0) return;
            Die();
        }

        public override void Heal(float points)
        {
            var newHealth = Stats.CurrentHealth + points;
            Stats.CurrentHealth = newHealth <= Stats.MaxHealth ? newHealth : Stats.MaxHealth;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Bullet)) return;
            if (!col.gameObject.TryGetComponent<Bullet>(out var bullet)) return;
            if (!(bullet.Type is BulletType.PlayerBullet)) return;
            ApplyDamage(bullet.Damage);
            Destroy(col.gameObject);
        }

        private IEnumerator DamageAnimation()
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = originalColor;
        }
    }
}