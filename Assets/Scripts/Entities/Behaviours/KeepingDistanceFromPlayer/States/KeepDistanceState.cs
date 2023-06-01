using System;
using UnityEngine;
using Utils;

namespace Behaviours.States
{
    public class KeepDistanceState : IState
    {
        private KeepingDistanceFromPlayer behaviour;
        
        public KeepDistanceState(KeepingDistanceFromPlayer behaviour)
        {
            this.behaviour = behaviour;
        }
        
        public void Tick()
        {
            var currentAngle = Vector3.SignedAngle(
                Vector3.right,
                behaviour.transform.position - behaviour.player.position,
                Vector3.forward
            );

            var angleDifference = currentAngle - behaviour.angleToKeep;
                
            if (angleDifference is > 10 or < -10)
            {
                GoAroundPlayer();
                return;
            }

            var distancesDifference = behaviour.DistancetoPlayer - behaviour.distanceToKeep;

            if (Math.Abs(distancesDifference) <= 1.0) return;

            GoToDistanceToKeep(distancesDifference, behaviour.DirectionTowardsPlayer);
        }
        
        private void GoAroundPlayer()
        {
            var playerToEnemy = behaviour.transform.position - behaviour.player.position;
            var orthogonal = Vector3.Cross(playerToEnemy, Vector3.forward);

            behaviour.transform.position += orthogonal.GetDirectionWithSpeed(behaviour.speed);
        }
        
        private void GoToDistanceToKeep(float distancesDifference, Vector3 directionTowardsPlayer)
        {
            var sign = Math.Sign(distancesDifference);
            var playerDirection = sign * directionTowardsPlayer.GetDirectionWithSpeed(behaviour.speed);
            var newPositionToPlayerDistance = Vector3.Distance(behaviour.transform.position + playerDirection, behaviour.player.position);

            if (newPositionToPlayerDistance < behaviour.minDistanceToPlayer
                || Math.Abs(newPositionToPlayerDistance - behaviour.distanceToKeep) <= 1.0
                || Math.Abs(distancesDifference) <= 1.0)
            {
                return;
            }

            behaviour.transform.position += playerDirection;
        }
        
        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}