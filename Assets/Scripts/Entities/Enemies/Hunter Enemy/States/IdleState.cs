namespace Enemies.HunterEnemy.States
{
    public class IdleState : IState
    {
        private HunterEnemy hunter;
        
        public IdleState(HunterEnemy hunter)
        {
            this.hunter = hunter;
        }
        
        public void Tick()
        {
            
        }

        public void OnEnter()
        {
         
        }

        public void OnExit()
        {
          
        }
        
        private void DoIdling()
        {
            StopShooting();
        }

        private void StopShooting()
        {
            // TODO
        }
    }
}