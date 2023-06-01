using DefaultNamespace;
using Enemies;
using UnityEngine;

namespace Waves
{
    public class EnemyWaveInfo : MonoBehaviour
    {
        [SerializeField] public Enemy Enemy;
        [SerializeField] public int Amount;
        [SerializeField] public Stats Stats;
    }
}