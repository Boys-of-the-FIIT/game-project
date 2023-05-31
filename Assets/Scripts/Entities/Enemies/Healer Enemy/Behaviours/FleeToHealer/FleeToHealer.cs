using System;
using Behaviours.FleeToHealer.States;
using DefaultNamespace;
using Enemies.HealerEnemy;
using UnityEngine;

namespace Behaviours.FleeToHealer
{
    public class FleeToHealer : MonoBehaviour
    {
        [SerializeField]public Entity entity;
        [Range(1, 99)][SerializeField] public float fleeHealPointsPercents;
        
        public HealerEnemy healer;
        private StateMachine stateMachine;
        
        private void Awake()
        {
            var health = new HealthyState();
            var findHealer = new FindHealerState(this);
            
            stateMachine.AddTransition(health, findHealer,  IsInjured());

            stateMachine = new StateMachine();

            Func<bool> IsInjured() => () => entity.IsInjured;
        }

        private void Update()
        {
            stateMachine.Tick();
            Debug.Log(stateMachine.CurrentState);
        }
    }
}