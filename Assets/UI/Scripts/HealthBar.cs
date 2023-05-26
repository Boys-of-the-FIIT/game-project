using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        private PlayerEntity player;
        
        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).GetComponent<PlayerEntity>();
            player.healthBarChanged?.AddListener(ChangeHealthBar);
        }

        private void ChangeHealthBar()
        {
            healthBar.value = player.Health / player.MaxHealth;
            Debug.Log(player.Health / player.MaxHealth);
        }

        private void OnDisable()
        {
            player.healthBarChanged?.RemoveListener(ChangeHealthBar);
        }
    }
}