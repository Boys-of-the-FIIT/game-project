using UnityEngine;
using Utils;

namespace Behaviours.States
{
    public class ChasePlayerState : IState
    {
        private KeepingDistanceFromPlayer behaviour;

        public ChasePlayerState(KeepingDistanceFromPlayer behaviour)
        {
            this.behaviour = behaviour;
        }

        public void Tick()
        {
            var newPosition = behaviour.transform.position +
                              behaviour.DirectionTowardsPlayer.GetDirectionWithSpeed(behaviour.speed);
            var newDistance = Vector3.Distance(behaviour.player.position, newPosition);

            if (newDistance > behaviour.minDistanceToPlayer)
            {
                behaviour.transform.position = newPosition;
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