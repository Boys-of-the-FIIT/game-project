using System;
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
        public UnityEvent healthBarChanged;
        
        private SceneStateManager sceneStateManager;
        private GameOverState gameOverState;

        [Inject]
        private void Construct(SceneStateManager manager, GameOverState gameOverState)
        {
            sceneStateManager = manager;
            this.gameOverState = gameOverState;
        }
        
        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public override void Die()
        {
            sceneStateManager.SwitchState(new GameOverState());
            Destroy(gameObject);
        }

        public override void ApplyDamage(float damage)
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Bullet))
            {
                var bullet = col.gameObject.GetComponent<Bullet>();
                if (bullet.Type is BulletType.EnemyBullet) 
                    ApplyDamage(bullet.damage);
                Destroy(col.gameObject);
            }
        }
    }
}