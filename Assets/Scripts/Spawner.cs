using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] enemyPrefabs;
        [SerializeField] private int maxObjectCount;
        [SerializeField] private float radius;
        private int currentObjectCount;
        private bool canSpawn = true;
        private Transform player;
        private System.Random random;
        
        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).transform;
            foreach (var enemyPrefab in enemyPrefabs)
                enemyPrefab.GetComponent<Enemy>().AttachToSpawner(this);
            random = new System.Random();
        }

        private void Update()
        {
            if (canSpawn && currentObjectCount < maxObjectCount)
                StartCoroutine(SpawnObject(enemyPrefabs[random.Next(0, enemyPrefabs.Length)]));
        }

        public void NotifyDead(Enemy enemy)
        {
            currentObjectCount--;
        }

        public IEnumerator SpawnObject(Enemy enemyPrefab)
        {
            var randomPos = Random.insideUnitSphere * radius + transform.position;
            currentObjectCount++;
            Instantiate(enemyPrefab, randomPos, transform.rotation);
            canSpawn = false;
            yield return new WaitForSeconds(2);
            canSpawn = true;
        }
    }
}