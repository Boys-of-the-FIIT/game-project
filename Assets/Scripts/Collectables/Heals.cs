using System;
using DefaultNamespace;
using UnityEngine;
using Utils;


namespace Player.Collectables
{
    public class Heals : Entity 
    {
        private Camera camera;
        [Range(0,100)][SerializeField] private int healthPercents;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Player)) return;
            if (!col.gameObject.TryGetComponent<PlayerEntity>(out var player)) return;
            if (!player.IsInjured) return;
            Destroy(gameObject);
        }

        public void Collect(Entity player)
        {
            player.Heal((healthPercents * player.Stats.MaxHealth) / 100);

        }

        public override void Die()
        {
            
        }

        public override void ApplyDamage(float damage)
        {
           
        }

        public override void Heal(float points)
        {
           
        }
    }
}