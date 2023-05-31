using UnityEngine;
using Utils;

namespace Enemies.HealerEnemy
{
    public class FindInjuredEnemyState : IState
    {
        private HealerEnemy healer;

        public FindInjuredEnemyState(HealerEnemy healer)
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
                if (!col.gameObject.CompareTag(Tags.Enemy)) return;
                if (!col.gameObject.TryGetComponent<Enemy>(out var enemy)) return;
                if (!enemy.IsInjured) return;
                Debug.Log("Entity found");
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