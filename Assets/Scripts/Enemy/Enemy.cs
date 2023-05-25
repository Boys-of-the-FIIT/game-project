using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour, IEntity
    {
        [SerializeField] private int health;

        public void Die()
        {
            // Play kill animation
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            // Make sprite red
            health -= damage;
            if (health <= 0)
                Die();
        }
    }
}