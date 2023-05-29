using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Zenject.SpaceFighter;

namespace DefaultNamespace
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] public Stats Stats;
        private EntitySpawner spawner;

        public EntitySpawner Spawner
        {
            get => spawner;
            set => spawner = value;
        }
        
        public abstract void Die();
        public abstract void ApplyDamage(int damage);
        public abstract void Heal(int points);
    }
}