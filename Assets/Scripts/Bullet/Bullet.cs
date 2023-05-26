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

        public BulletType Type => type;

        private Rigidbody2D rb;
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
            if (col.gameObject.CompareTag(Tags.Enemy) && type == BulletType.PlayerBullet)
            {   
                Debug.Log("Damage taken!");
                var enemy = col.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
            }
            else if (col.gameObject.CompareTag(Tags.Player) && type == BulletType.EnemyBullet)
            {
                var player = col.gameObject.GetComponent<PlayerEntity>();
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        public void SetType(BulletType type)
        {
            this.type = type;
        }
    }
}