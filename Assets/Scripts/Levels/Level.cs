using System;
using DefaultNamespace.Level_Stats;
using Player;
using Player.Collectables;
using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private EntitySpawner[] spawners;
        [SerializeField] private LevelStatistics levelStatistics;

        private PlayerEntity player;
        
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }
        
        private void Awake()
        {
            foreach (var spawner in spawners)
            {
                spawner.OnSpawnerEnemyDead.AddListener(AddPoints);                
            }
        }

        private void AddPoints(Entity enemy)
        {
            player.Stats.UpgradePoints += enemy.Stats.UpgradePoints;
        }
    }
}