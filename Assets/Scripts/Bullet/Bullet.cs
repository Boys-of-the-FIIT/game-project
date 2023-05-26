using System;
using DefaultNamespace;
using Player;
using UnityEngine;
using Utils;

namespace Bullet
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


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            startPosition = transform.position;
            rb.velocity = transform.right * speed;
        }

        private void Update()
        {
            if (Vector3.Distance(startPosition, transform.position) > maxDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Enemy) && Type == BulletType.PlayerBullet)
            {
                var enemy = col.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
            }
            else if (col.gameObject.CompareTag(Tags.Player) && Type == BulletType.EnemyBullet)
            {
                var player = col.gameObject.GetComponent<PlayerEntity>();
                player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}