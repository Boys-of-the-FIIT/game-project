using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = System.Random;


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
        private Random random;
        private DiContainer diContainer;
        private Camera mainCamera;

        [Inject]
        private void Construct(DiContainer diContainer, Camera camera)
        {
            this.diContainer = diContainer;
            this.mainCamera = camera;
        }

        private void Start()
        {
            parentTransform = GetComponentInParent<Transform>();
            random = new Random();
            Debug.Log($"Screen Height: {Screen.height}");
            Debug.Log($"Screen Width: {Screen.width}");
        }

        private void Update()
        {
            // Debug.Log($"Camera Pos: {mainCamera}");
            if (canSpawn && currentObjectCount < maxObjectCount && prefabs.Length > 0)
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