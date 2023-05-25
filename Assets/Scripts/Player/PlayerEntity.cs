using System;
using DefaultNamespace;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerEntity : MonoBehaviour, IEntity
    {
        [SerializeField] private float health;

        public void Die()
        {
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
                Debug.Log("Bullet!");
                TakeDamage(col.gameObject.GetComponent<Bullet.Bullet>().damage);
            }
        }
    }
}