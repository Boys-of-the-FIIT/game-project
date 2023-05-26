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

        [SerializeField] private BulletTrailScriptableObject trailConfig;
        private TrailRenderer trail;

        [SerializeField] private Renderer renderer;
        private bool isDisabling;
        private Vector3 _startPosition;

        private const string DISABLE_METHOD_NAME = "Disable";
        private const string DO_DISABLE_METHOD_NAME = "DoDisable";


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
            trail = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            renderer.enabled = true;
            CancelInvoke(DISABLE_METHOD_NAME);
            ConfigureTrail();
            Invoke(DISABLE_METHOD_NAME, 2);
        }

        private void ConfigureTrail()
        {
            if (trail is not null && trailConfig is not null)
            {
                trailConfig.SetUpTrail(trail);
            }
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

        protected void Disable()
        {
            CancelInvoke(DISABLE_METHOD_NAME);
            CancelInvoke(DO_DISABLE_METHOD_NAME);
            rb.velocity = Vector3.zero;
            renderer.enabled = false;

            if (trail is not null && trailConfig is not null)
            {
                isDisabling = true;
                Invoke(DO_DISABLE_METHOD_NAME, trailConfig.durationTime);
            }
            else
            {
                DoDisable();
            }
        }

        private void DoDisable()
        {
            if (trail is not null && trailConfig is not null)
            {
                trail.Clear();
            }

            gameObject.SetActive(false);
        }
    }
}