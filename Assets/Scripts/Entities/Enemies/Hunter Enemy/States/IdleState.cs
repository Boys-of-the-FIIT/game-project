using UnityEngine;

namespace Enemies.HunterEnemy.States
{
    public class IdleState : IState
    {
        private HunterEnemy hunter;
        private EnemyAttack attack;
        
        public IdleState(HunterEnemy hunter)
        {
            this.hunter = hunter;
        }
        
        public void OnEnter()
        {
            if (hunter.TryGetComponent<EnemyAttack>(out attack))
                attack.enabled = false;
        }

        public void OnExit()
        {
            attack.enabled = true;
        }
        
        public void Tick()
        {
            
        }
    }
}