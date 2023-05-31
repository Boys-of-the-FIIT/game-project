namespace Enemies.HealerEnemy
{
    public class HealTargetState : IState
    {
        private HealerEnemy healer;
        
        public HealTargetState(HealerEnemy healer)
        {
            this.healer = healer;
        }
        
        public void Tick()
        {
            healer.HealTarget.Heal(healer.healPoints);
            healer.CanHeal = false;
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}