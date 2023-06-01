using System;
using System.Collections;
using Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace Waves
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private EntityWaveSpawner spawner;
        [SerializeField] private Wave[] waves;
        [SerializeField] private float breakTime;

        [HideInInspector] public UnityEvent OnWaveFinished;
        
        public float CurrentTime { get; set; }
        public Wave CurrentWave { get; set; }
        public bool IsBreak { get; set; }

        private IEnumerator wavesCycleCoroutine;

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