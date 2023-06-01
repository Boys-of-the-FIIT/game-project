using System;
using System.Collections;
using Bullets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using Zenject;
using Random = System.Random;


namespace DefaultNamespace
{
    public class EntitySpawner : Entity
    {
        [SerializeField] private Entity[] prefabs;
        [SerializeField] private int maxObjectCount;
        [SerializeField] private float radius;
        [SerializeField] private float spawnDelay = 2;

        public UnityEvent<Entity> OnSpawnerEnemyDead;
        
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private Color damageColor;
        
        private int currentObjectCount;
        private bool canSpawn = true;
        private Random random;
        private DiContainer diContainer;
        private Camera mainCamera;

        private Vector3 CameraPos => mainCamera.transform.position;

        [Inject]
        private void Construct(DiContainer diContainer, Camera camera)
        {
            this.diContainer = diContainer;
            this.mainCamera = camera;
        }
        private void Awake()
        {
            Stats.CurrentHealth = Stats.MaxHealth;
        }
        
        private void Start()
        {
            TryGetComponent<SpriteRenderer>(out spriteRenderer);
            originalColor = spriteRenderer.color;
            damageColor = Color.red;
            random = new Random();
        }

        private void Update()
        {
            if (canSpawn && currentObjectCount < maxObjectCount && prefabs.Length > 0)
                StartCoroutine(SpawnEntity(prefabs[random.Next(0, prefabs.Length)]));
        }

        private float GetSpawnCenterOffset(Transform enemy, Transform enemyParent)
        {
            // var offset = Mathf.Min(parentTransform.localScale.x, parentTransform.localScale.y);
            var offset = Mathf.Min(enemy.transform.localScale.x, enemy.transform.localScale.y);
            offset += 5f;
            return offset;
        }

        public void NotifyDead(Entity entity)
        {
            currentObjectCount--;
            OnSpawnerEnemyDead?.Invoke(entity);
        }

        public IEnumerator SpawnEntity(Entity entityPrefab)
        {
            var offset = GetSpawnCenterOffset(entityPrefab.transform, transform);
            var cameraOffsetRadius = 2 * mainCamera.orthographicSize * mainCamera.aspect;
            var positionToSpawn =
                RandomExtensions.GetRandomPositionInCircle(transform.position, offset, radius + cameraOffsetRadius);
            if (Vector2.Distance(positionToSpawn, CameraPos) < cameraOffsetRadius)
                yield break;

            var obj = diContainer.InstantiatePrefabForComponent<Entity>(
                entityPrefab,
                positionToSpawn,
                transform.rotation,
                null
            );

            currentObjectCount++;

            obj.OnEntityDeath.AddListener(OnEntityDeath());
            canSpawn = false;
            yield return new WaitForSeconds(spawnDelay);
            canSpawn = true;
            
            UnityAction<Entity> OnEntityDeath() => (obj) => NotifyDead(obj);
        }

        public override void Die() => Destroy(gameObject);

        public override void ApplyDamage(float damage)
        {
            if (spriteRenderer) StartCoroutine(DamageAnimation());
            Stats.CurrentHealth -= damage;
            if (Stats.CurrentHealth > 0) return;
            Die();
        }

        public override void Heal(float points)
        {
            var newHealth = Stats.CurrentHealth + points;
            Stats.CurrentHealth = newHealth <= Stats.MaxHealth ? newHealth : Stats.MaxHealth;
        }
        
        private IEnumerator DamageAnimation()
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = originalColor;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Bullet)) return;
            if (!col.gameObject.TryGetComponent<Bullet>(out var bullet)) return;
            if (!(bullet.Type is BulletType.PlayerBullet)) return;
            ApplyDamage(bullet.Damage);
            Destroy(col.gameObject);
        }
    }
}