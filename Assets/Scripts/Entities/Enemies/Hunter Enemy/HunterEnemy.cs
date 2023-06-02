using System;
using Enemies.HunterEnemy.States;
using Player;
using UnityEngine;
using Zenject;

namespace Enemies.HunterEnemy
{
    public class HunterEnemy : Enemy
    {
        [SerializeField] internal float hidingCoefficient = 1;
        [SerializeField] internal float startIdlingDistance = 10;
        [SerializeField] internal float startHidingDistance = 20;

        internal SpriteRenderer[] spriteRenderers;
        internal Canvas healthBarCanvas;

        private PlayerEntity player;

        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
            spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
            healthBarCanvas = gameObject.GetComponentInChildren<Canvas>();
        }

        private StateMachine stateMachine;

        private float DistanceToPlayer => (player.transform.position - transform.position).magnitude;

        private void Awake()
        {
            var idleState = new IdleState(this);
            var hideState = new HideState(this);
            var unhideState = new UnhideState(this);

            stateMachine = new StateMachine();

            stateMachine.AddTransition(hideState, idleState, InIdleDistance());
            stateMachine.AddTransition(idleState, hideState, () => true);
            stateMachine.AddTransition(hideState, idleState, OutOfIdleDistance());
            stateMachine.AddTransition(hideState, unhideState, OutOfHidingDistance());
            stateMachine.AddTransition(unhideState, hideState, InHidingDistance());

            stateMachine.SetState(unhideState);

            Func<bool> OutOfIdleDistance() => () => DistanceToPlayer > startIdlingDistance;
            Func<bool> OutOfHidingDistance() => () => DistanceToPlayer > startHidingDistance; 
            Func<bool> InHidingDistance() => () => DistanceToPlayer <= startHidingDistance;
            Func<bool> InIdleDistance() => () => DistanceToPlayer <= startIdlingDistance;
        }

        private void Update()
        {
            Debug.Log(stateMachine.CurrentState);
            stateMachine.Tick();
        }
    }
}