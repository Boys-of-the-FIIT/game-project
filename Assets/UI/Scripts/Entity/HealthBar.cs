using System;
using DefaultNamespace;
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
        private Entity entity;
        
        private void Start()
        {
            entity = GetComponentInParent<Entity>();
        }

        private void Update()
        {
            healthBar.value = entity.Stats.CurrentHealth / entity.Stats.MaxHealth;
        }
    }
}