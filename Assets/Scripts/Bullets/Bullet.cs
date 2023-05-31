using System;
using UnityEngine;
using Utils;

namespace Bullets
{
    public class Bullet : MonoBehaviour
    {
        private float speed;
        private float maxDistance;
        private float damage;
        private BulletType type;

        public Bullet Construct(BulletType type, float damage, float maxDistance, float speed)
        {
            this.type = type;
            this.damage = damage;
            this.maxDistance = maxDistance;
            this.speed = speed;
            return this;
        }

        public BulletType Type
        {
            get => type;
            set => type = value;
        }
        
        public float Damage
        {
            get => damage;
            set => damage = value;
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