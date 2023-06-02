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
            Debug.Log("OnEnter");
            attack = hunter.GetComponentInChildren<EnemyAttack>();
            
            if (attack is null) return;
            
            Debug.Log("Disable Attack");
            attack.enabled = false;
        }

        public void OnExit()
        {
            Debug.Log("Enable Attack");
            attack.enabled = true;
        }

        public void Tick()
        {
        }
    }
}