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
        [HideInInspector] public UnityEvent<Entity> OnEntityDeath = new UnityEvent<Entity>();
        public bool IsInjured => Stats.CurrentHealth < Stats.MaxHealth;

        public abstract void Die();
        public abstract void ApplyDamage(float damage);
        public abstract void Heal(float points);
    }
}