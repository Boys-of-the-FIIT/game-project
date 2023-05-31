using UnityEngine;

namespace Enemies.HealerEnemy
{
    public class RestoreHealAbilityState : IState
    {
        private HealerEnemy healer;
        private float remainingSeconds;
        
        public RestoreHealAbilityState(HealerEnemy healer)
        {
            this.healer = healer;
        }
        
        public void OnEnter()
        {
            remainingSeconds = healer.healDelaySeconds;
        }
        
        public void Tick()
        {
            remainingSeconds -= Time.deltaTime;
            if (remainingSeconds < 0)
                healer.CanHeal = true;
        }

        public void OnExit()
        {
            
        }
    }
}