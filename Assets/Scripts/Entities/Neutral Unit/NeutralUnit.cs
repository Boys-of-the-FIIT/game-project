using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace.Entities.Neutral_Unit
{
    public class NeutralUnit : Entity
    {
        public override void Die()
        {
            Destroy(gameObject);
        }

        public override void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) Die();
        }

        public override void Heal(float points)
        {
            CurrentHealth += points;
        }
    }
}