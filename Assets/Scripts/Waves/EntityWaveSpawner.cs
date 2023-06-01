using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = System.Random;

namespace Waves
{
    public class EntityWaveSpawner : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private float spawnDelay = 2;
        
        [HideInInspector] public UnityEvent<Entity> OnSpawnerEnemyDead = new UnityEvent<Entity>();

        public Wave Wave { get; set; }
        
        private Camera mainCamera;
        private DiContainer diContainer;
        private IEnumerator spawnEntityCoroutine;
        private IEnumerator spawnCycleCoroutine;
        private Random random;

        private Vector3 CameraPos => mainCamera.transform.position;

        [Inject]
        private void Construct(DiContainer diContainer, Camera mainCamera)
        {
            this.mainCamera = mainCamera;
            this.diContainer = diContainer;
        }

        private void Awake()
        {
            spawnEntityCoroutine = SpawnCoroutine();
            spawnCycleCoroutine = SpawnCycleCoroutine();
            random = new Random();
        }

        private void NotifyDead(Entity entity)
        {
            OnSpawnerEnemyDead?.Invoke(entity);
        }

        public void StartSpawning()
        {
            StartCoroutine(spawnCycleCoroutine);
        }

        public void StopSpawning()
        {
            StopCoroutine(spawnCycleCoroutine);
        }

        public IEnumerator SpawnCycleCoroutine()
        {
            while (true)
            { 
                yield return StartCoroutine(SpawnCoroutine());
            }
        }
        
        private IEnumerator SpawnCoroutine()
        {
            if (Wave.enemyInfo.Count == 0) yield break;
            var enemyInfo = Wave.enemyInfo[random.Next(0, Wave.enemyInfo.Count)];
            if (enemyInfo.amount == 0) yield break;
            
            // var offset = 2 * mainCamera.orthographicSize * mainCamera.aspect;
            var offset = 0;
            var positionToSpawn =
                RandomExtensions.GetRandomPositionInCircle(CameraPos, offset, radius);
            if (Vector2.Distance(positionToSpawn, CameraPos) < offset)
                yield break;

            var obj = diContainer.InstantiatePrefabForComponent<Entity>(
                enemyInfo.enemy,
                positionToSpawn,
                transform.rotation,
                null
            );
            obj.Stats = enemyInfo.stats;
            obj.OnEntityDeath.AddListener(OnEntityDeath());
            enemyInfo.amount--;
            yield return new WaitForSeconds(spawnDelay);
            UnityAction<Entity> OnEntityDeath() => (obj) => NotifyDead(obj);
        }
    }
}