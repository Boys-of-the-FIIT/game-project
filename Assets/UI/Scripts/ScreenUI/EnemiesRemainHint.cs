using System;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using Waves;
using Zenject;

namespace UI.Scripts
{
    public class EnemiesRemainHint : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        private WaveManager waveManager;
        private EntityWaveSpawner waveSpawner;
        private float currentEnemyRemained;
        
        [Inject]
        private void Construct(EntityWaveSpawner waveSpawner, WaveManager waveManager)
        {
            this.waveSpawner = waveSpawner;
            this.waveManager = waveManager;

            waveManager.OnWaveStarted.AddListener(SetupCounter);
            waveSpawner.OnSpawnerEnemyDead.AddListener(UpdateCounter);
            waveManager.OnWaveFinished.AddListener(HideCounter);
        }

        private void HideCounter()
        {
            textMesh.enabled = false;
        }
        
        private void SetupCounter(Wave wave)
        {
            currentEnemyRemained = wave.EnemyCount;
            textMesh.enabled = true;
        }
        
        private void UpdateCounter(Entity entity)
        {
            currentEnemyRemained--;
            textMesh.text = $"Enemies remained: {currentEnemyRemained}";
        }
    }
}