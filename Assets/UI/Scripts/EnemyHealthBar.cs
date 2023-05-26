using System;
using DefaultNamespace;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        private Enemy enemy;
        
        private void Start()
        {
            enemy = GetComponentInParent<Enemy>();
            enemy.healthBarChanged?.AddListener(ChangeHealthBar);
        }

        private void ChangeHealthBar()
        {
            healthBar.value = enemy.Health / enemy.MaxHealth;
            Debug.Log(enemy.Health / enemy.MaxHealth);
        }

        private void OnDisable()
        {
            enemy.healthBarChanged?.RemoveListener(ChangeHealthBar);
        }
    }
}