using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;


namespace DefaultNamespace
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private Entity[] prefabs;
        [SerializeField] private int maxObjectCount;
        [SerializeField] private float radius;
        [SerializeField] private float spawnDelay = 2;

        private int currentObjectCount;
        private bool canSpawn = true;
        private Transform parentTransform;
        private System.Random random;

        [Inject] private DiContainer diContainer;

        private void Start()
        {
            parentTransform = GetComponentInParent<Transform>();
            random = new System.Random();
        }

        private void Update()
        {
            if (canSpawn && currentObjectCount < maxObjectCount)
                StartCoroutine(SpawnEntity(prefabs[random.Next(0, prefabs.Length)]));
        }

        private float GetSpawnCenterOffset(Transform enemy, Transform enemyParent)
        {
            var offset = Mathf.Min(parentTransform.localScale.x, parentTransform.localScale.y);
            offset += Mathf.Min(enemy.transform.localScale.x, enemy.transform.localScale.y);
            offset += 5f;
            return offset;
        }

        public void NotifyDead()
        {
            currentObjectCount--;
        }

        public IEnumerator SpawnEntity(Entity enemyPrefab)
        {
            var offset = GetSpawnCenterOffset(enemyPrefab.transform, parentTransform.transform);
            var positionToSpawn = RandomExtensions.GetRandomPositionInCircle(transform.position, offset, radius);

            var obj = diContainer.InstantiatePrefabForComponent<Entity>(
                enemyPrefab,
                positionToSpawn,
                transform.rotation,
                null
            );

            currentObjectCount++;
            obj.Spawner = this;

            canSpawn = false;
            yield return new WaitForSeconds(spawnDelay);
            canSpawn = true;
        }
    }
}