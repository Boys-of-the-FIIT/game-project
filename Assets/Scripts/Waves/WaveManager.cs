using System;
using System.Collections;
using System.Linq;
using Enemies;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Waves
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        [SerializeField] private float breakTime;

        public float CurrentTime { get; set; }
        public Wave CurrentWave { get; set; }
        public bool IsBreak { get; set; }

        private IEnumerator wavesCycleCoroutine;
        private EntityWaveSpawner spawner;
        
        [Inject]
        private void Construct(EntityWaveSpawner spawner)
        {
            this.spawner = spawner;
        }
        
        private void Start()
        {
            StartCoroutine(WavesCycleCoroutine());
        }

        private IEnumerator WavesCycleCoroutine()
        {
            foreach (var wave in waves)
            {
                CurrentWave = wave;
                yield return StartCoroutine(WaveCycleCoroutine());
                yield return StartCoroutine(BetweenWaveBreak());
            }
        }

        private IEnumerator BetweenWaveBreak()
        {
            IsBreak = true;
            CurrentTime = breakTime;
            while (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
                yield return null;
            }
            IsBreak = false;
        }
        
        private IEnumerator WaveCycleCoroutine()
        {
            spawner.Wave = CurrentWave;
            spawner.StartSpawning();
            CurrentTime = CurrentWave.Duration;
            while (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
                yield return null;
            }
            spawner.StopSpawning();
            spawner.Wave = null;
            ClearEnemiesFromScene();
        }

        private void ClearEnemiesFromScene()
        {
            foreach (var enemy in GameObject.FindObjectsOfType<Enemy>())
                Destroy(enemy.gameObject);
        }
    }
}