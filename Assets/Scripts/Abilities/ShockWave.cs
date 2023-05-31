using System;
using System.Collections;
using Enemies;
using Enemies.HunterEnemy;
using Player;
using UnityEngine;
using Utils;

namespace DefaultNamespace.Abilities
{
    public class ShockWave : Ability
    {
        [SerializeField] private int damage;

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        public override void Invoke()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach(var collider in colliders)
            {
                if (!collider.gameObject.CompareTag(Tags.Enemy)) return;
                if (!collider.gameObject.TryGetComponent<Enemy>(out var enemy)) return;
                // if (!collider.gameObject.TryGetComponent<Rigidbody2D>(out var enemyRb)) return;
                enemy.ApplyDamage(damage);
                // enemyRb.AddForce(enemy.transform.position - transform.position);
                var hunterEnemy = new HunterEnemy();
            }
        }
    }
}