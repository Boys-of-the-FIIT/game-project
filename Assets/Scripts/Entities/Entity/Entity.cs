using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Zenject.SpaceFighter;

namespace DefaultNamespace
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float currentCurrentHealth;
        private EntitySpawner spawner;
        
        public float CurrentHealth
        {
            get => currentCurrentHealth;
            protected set => currentCurrentHealth = value;
        } 
        
        public float MaxHealth
        {
            get => maxHealth;
            protected set => maxHealth = value;
        }

        public EntitySpawner Spawner
        {
            get => spawner;
            set => spawner = value;
        }
        
        public abstract void Die();
        public abstract void ApplyDamage(float damage);
        public abstract void Heal(float points);
    }
}