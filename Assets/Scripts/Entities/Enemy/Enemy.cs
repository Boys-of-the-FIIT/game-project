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
            CurrentHealth = MaxHealth;
        }

        public override void Die()
        {
            Spawner?.NotifyDead();
            Destroy(gameObject);
        }

        public override void ApplyDamage(float damage)
        {
            StartCoroutine(DamageAnimation());
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
                Die();
        }

        public override void Heal(float points)
        {
            CurrentHealth += points;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Bullet))
            {
                var bullet = col.gameObject.GetComponent<Bullet>();
                if (bullet.Type is BulletType.PlayerBullet) 
                    ApplyDamage(bullet.damage);
            }
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