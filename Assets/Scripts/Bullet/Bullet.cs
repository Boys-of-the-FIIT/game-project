using System;
using DefaultNamespace;
using UnityEngine;
using Utils;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float maxDistance;
        [SerializeField] public int damage;
        private Vector3 _startPosition;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _startPosition = transform.position;
            rb.velocity = transform.right * speed;
        }

        private void Update()
        {
            if (Vector3.Distance(_startPosition, transform.position) > maxDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == Tags.Enemy)
            {   
                var enemy = col.gameObject.GetComponent<Enemy>();
                if (enemy.gameObject != col.gameObject)
                    enemy.TakeDamage(damage);
            }
        }
    }
}