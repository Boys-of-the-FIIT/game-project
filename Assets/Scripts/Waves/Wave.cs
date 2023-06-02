using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Waves
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] private float duration;
        
        public float Duration
        {
            get => duration;
            set => duration = value;
        }

        [SerializeField] private string name;
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int EnemyCount => enemyInfo.Select(x => x.Amount).Sum();
        public List<EnemyWaveInfo> enemyInfo;
    }
}