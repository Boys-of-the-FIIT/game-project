using System;
using UnityEngine;
using Utils;

namespace Player.Collectables
{
    public class Heals : MonoBehaviour
    {
        private Camera camera;
        [Range(0,100)][SerializeField] private int healthPercents;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Player)) return;
            if (!col.gameObject.TryGetComponent<PlayerEntity>(out var player)) return;
            if (!player.IsInjured) return;
            player.Heal((healthPercents * player.Stats.MaxHealth) / 100);
            Destroy(gameObject);
        }
    }
}