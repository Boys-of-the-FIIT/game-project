using UnityEngine;

namespace Enemies.HealerEnemy
{
    public class FollowTargetState : IState
    {
        private HealerEnemy healer;

        public FollowTargetState(HealerEnemy healer)
        {
            this.healer = healer;
        }

        public void Tick()
        {
            healer.transform.position = Vector2.MoveTowards(
                healer.transform.position,
                healer.HealTarget.transform.position,
                Time.deltaTime * healer.Stats.Speed
            );
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}