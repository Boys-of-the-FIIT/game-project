using UnityEngine;
using Utils;

namespace Enemies.HealerEnemy
{
    public class SearchForInjuredEnemyState : IState
    {
        private HealerEnemy healer;

        public SearchForInjuredEnemyState(HealerEnemy healer)
        {
            this.healer = healer;
        }

        public void Tick()
        {
            var collisions = Physics2D.OverlapCircleAll(
                healer.transform.position, 
                healer.searchForTargetDistance
                );
            foreach (var col in collisions)
            {
                if (!col.gameObject.CompareTag(Tags.Enemy)) continue;
                if (!col.gameObject.TryGetComponent<Enemy>(out var enemy)) continue;
                if (!enemy.IsInjured) continue;
                healer.HealTarget = enemy;
            }
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}