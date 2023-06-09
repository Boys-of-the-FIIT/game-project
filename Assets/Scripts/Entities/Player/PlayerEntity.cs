﻿using System;
using Bullets;
using DefaultNamespace;
using JetBrains.Annotations;
using States.Game_States;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Zenject;

namespace Player
{
    public class PlayerEntity : Entity
    {
        private SceneStateManager manager;
        private GameOverState gameOverState;

        [Inject]
        private void Construct(SceneStateManager manager, GameOverState gameOverState)
        {
            this.manager = manager;
            this.gameOverState = gameOverState;
        }
        
        private void Start()
        {
            Stats.CurrentHealth = Stats.MaxHealth;
        }

        public override void Die()
        {
            manager.SwitchState(new GameOverState());
            Destroy(gameObject);
        }

        public override void ApplyDamage(float damage)
        {
            Stats.CurrentHealth -= damage;
            if (Stats.CurrentHealth <= 0)
                Die();
        }

        public override void Heal(float points)
        {
            Stats.CurrentHealth += points;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Bullet)) return;
            if (!col.gameObject.TryGetComponent<Bullet>(out var bullet)) return;
            if (!(bullet.Type is BulletType.EnemyBullet)) return;
            ApplyDamage(bullet.Damage);
            Destroy(col.gameObject);
        }
    }
}