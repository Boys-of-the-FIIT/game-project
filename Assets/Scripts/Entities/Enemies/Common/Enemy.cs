using System;
using System.Collections;
using Bullets;
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
            Stats.CurrentHealth = Stats.MaxHealth;  
        }

        public override void Die()
        {
            Spawner?.NotifyDead();
            Destroy(gameObject);
        }

        public override void ApplyDamage(int damage)
        {
            StartCoroutine(DamageAnimation());
            Stats.CurrentHealth -= damage;
            if (Stats.CurrentHealth <= 0)
                Die();
        }

        public override void Heal(int points)
        {
            Stats.CurrentHealth += points;
        }

        public bool IsInjured => Stats.CurrentHealth < Stats.MaxHealth;
        
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