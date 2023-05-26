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
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private int maxObjectCount;
        [SerializeField] private float radius;
        private int currentObjectCount;
        private bool canSpawn = true;
        private Transform player;

        private void Start()
        {
            player = GameObject.FindWithTag(Tags.Player).transform;
            enemyPrefab.GetComponent<Enemy>().AttachToSpawner(this);
        }

        private void Update()
        {
            if (canSpawn && currentObjectCount < maxObjectCount)
                StartCoroutine(SpawnObject(enemyPrefab));
        }

        public void NotifyDead(Enemy enemy)
        {
            currentObjectCount--;
        }
        

        public IEnumerator SpawnObject(Enemy enemyPrefab)
        {
            var randomPos = Random.insideUnitSphere * radius + transform.position;
            var nearbyPlayer = Vector3.Distance(randomPos, player.transform.position) < 10;
            if (!nearbyPlayer)
            {
                currentObjectCount++;
                Instantiate(enemyPrefab, randomPos, transform.rotation);
                canSpawn = false;
                yield return new WaitForSeconds(2);
            }
            canSpawn = true;
        }
    }
}