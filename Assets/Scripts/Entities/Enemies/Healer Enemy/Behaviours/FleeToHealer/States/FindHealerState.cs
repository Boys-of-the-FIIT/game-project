using Enemies.HealerEnemy;
using UnityEngine;
using Utils;

namespace Behaviours.FleeToHealer.States
{
    public class FindHealerState : IState
    {
        private FleeToHealer behaviour;
        
        public FindHealerState(FleeToHealer behaviour)
        {
            this.behaviour = behaviour;
        }
        
        public void Tick()
        {
            var colliders = Physics2D.OverlapCircleAll(behaviour.transform.position, 20);
            foreach (var col in colliders)
            {
                if (!col.gameObject.CompareTag(Tags.Enemy)) return;
                if (!col.gameObject.TryGetComponent<HealerEnemy>(out var healer)) return;
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