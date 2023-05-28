using System;
using UnityEngine;
using Utils;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxDistance;
        [SerializeField] public int damage;
        [SerializeField] private BulletType type;
        
        public BulletType Type
        {
            get => type;
            set => type = value;
        }

        private Rigidbody2D rb;
        private Vector3 startPosition;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
            rb.velocity = transform.right * speed;
        }

        private void Update()
        {
            if (Vector3.Distance(startPosition, transform.position) > maxDistance)
                Destroy(gameObject);
        }
    }
}