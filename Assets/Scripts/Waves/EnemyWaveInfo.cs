using DefaultNamespace;
using Enemies;
using UnityEngine;

namespace Waves
{
    public class EnemyWaveInfo : MonoBehaviour
    {
        [SerializeField] public Enemy enemy;
        [SerializeField] public int amount;
        [SerializeField] public Stats stats;
    }
}