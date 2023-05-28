using System;
using System.Collections;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private Entity[] prefabs;
        [SerializeField] private int maxObjectCount;
        [SerializeField] private float radius;
        
        [Inject] private DiContainer diContainer;
        [Inject] private PlayerEntity player;
        
        private int currentObjectCount;
        private bool canSpawn = true;
        private Transform parentTransform;
        private System.Random random;

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
            var randomPos = Random.insideUnitSphere * (radius + offset) + transform.position;
            currentObjectCount++;
            var obj = diContainer.InstantiatePrefabForComponent<Entity>(enemyPrefab, randomPos, transform.rotation, null);
            obj.Spawner = this;
            canSpawn = false;
            yield return new WaitForSeconds(2);
            canSpawn = true;
        }
    }
}