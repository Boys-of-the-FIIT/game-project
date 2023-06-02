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
        
        public void StartSpawning()
        {
            StartCoroutine(spawnCycleCoroutine);
        }

        public void StopSpawning()
        {
            StopCoroutine(spawnCycleCoroutine);
        }
        
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

        private IEnumerator SpawnCycleCoroutine()
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
            if (enemyInfo.Amount == 0) yield break;
            
            var offset = mainCamera.orthographicSize * mainCamera.aspect;
            var positionToSpawn =
                RandomExtensions.GetRandomPositionInCircle(CameraPos, offset, radius);
            if (Vector2.Distance(positionToSpawn, CameraPos) < offset)
                yield break;

            var obj = diContainer.InstantiatePrefabForComponent<Entity>(
                enemyInfo.Enemy,
                positionToSpawn,
                transform.rotation,
                null
            );
            var objStats = Instantiate<Stats>(enemyInfo.Stats);
            objStats.transform.SetParent(obj.transform);
            obj.Stats = objStats;
            obj.OnEntityDeath.AddListener(OnEntityDeath());
            enemyInfo.Amount--;
            yield return new WaitForSeconds(spawnDelay);
            
            UnityAction<Entity> OnEntityDeath() => (obj) => OnSpawnerEnemyDead.Invoke(obj);
        }
    }
}