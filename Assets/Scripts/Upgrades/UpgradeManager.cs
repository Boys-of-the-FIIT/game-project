﻿using System;
using DefaultNamespace;
using Player;
using UnityEngine;
using Waves;
using Zenject;

namespace Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        private PlayerEntity player;
        private EntityWaveSpawner enemySpawner;
        private Stats playerStats;
        
        [Inject]
        private void Construct(PlayerEntity player, EntityWaveSpawner enemySpawner)
        {
            this.player = player;
            this.playerStats = player.Stats;
            this.enemySpawner = enemySpawner;
            enemySpawner.OnSpawnerEnemyDead.AddListener(OnEnemyDeath);
        }

        private void OnEnemyDeath(Entity enemy)
        {
            playerStats.UpgradePoints += enemy.Stats.UpgradePoints;
        }
    }
}