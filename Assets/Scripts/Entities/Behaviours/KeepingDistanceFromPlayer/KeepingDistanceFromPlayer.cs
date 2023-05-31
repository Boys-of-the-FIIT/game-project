using System;
using Behaviours.States;
using Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using Utils;

namespace Behaviours
{
    public class KeepingDistanceFromPlayer : MonoBehaviour
    {
        [SerializeField] internal float minDistanceToPlayer = 5;
        [SerializeField] internal float maxDistanceToPlayer = 10;
        [SerializeField] internal float speed;
        
        internal Transform player;
        internal float angleToKeep;
        internal float distanceToKeep;

        internal Vector3 DirectionTowardsPlayer => player.position - transform.position;
        internal float DistancetoPlayer => DirectionTowardsPlayer.magnitude;
        
        private StateMachine stateMachine;
        
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player.transform;
        }

        private void Awake()
        {
            angleToKeep = Random.Range(-180f, 180f);
            distanceToKeep =
                Random.Range(minDistanceToPlayer, maxDistanceToPlayer);
            var runFromPlayerState = new RunFromPlayerState(this);
            var keepDistanceState = new KeepDistanceState(this);
            var chasePlayerState = new ChasePlayerState(this);
            
            stateMachine = new StateMachine();

            stateMachine.AddTransition(runFromPlayerState, keepDistanceState, BetweenMaxAndMinDistance());
            stateMachine.AddTransition(keepDistanceState, chasePlayerState, OutOfMaxDistanceToPlayer());
            stateMachine.AddTransition(chasePlayerState, keepDistanceState, BetweenMaxAndMinDistance());
            stateMachine.AddTransition(keepDistanceState, runFromPlayerState, InMinDistanceToPlayer());

            stateMachine.SetState(chasePlayerState);
            
            Func<bool> InMinDistanceToPlayer() => () => DistancetoPlayer < minDistanceToPlayer;
            Func<bool> BetweenMaxAndMinDistance() => () => minDistanceToPlayer < DistancetoPlayer && DistancetoPlayer <= maxDistanceToPlayer;
            Func<bool> OutOfMaxDistanceToPlayer() => () => DistancetoPlayer > maxDistanceToPlayer;
        }

        private void Update() => stateMachine.Tick();
    }
}