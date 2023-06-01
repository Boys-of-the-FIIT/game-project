using UnityEngine;
using Utils;

namespace Behaviours.States
{
    public class RunFromPlayerState : IState
    {
        private KeepingDistanceFromPlayer behaviour;
        
        public RunFromPlayerState(KeepingDistanceFromPlayer behaviour)
        {
            this.behaviour = behaviour;
        }
        
        public void Tick()
        {
            behaviour.transform.position -= behaviour.DirectionTowardsPlayer.GetDirectionWithSpeed(behaviour.speed);
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}