using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour, IEntity
    {
        [SerializeField] private int health;
        [SerializeField] private GameObject bulletPrefab;
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
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == Tags.Bullet)
            {
                TakeDamage(col.gameObject.GetComponent<Bullet.Bullet>().damage);
            }
        }
    }
}