namespace Behaviours.FleeToHealer.States
{
    public class MoveToHealerState : IState
    {
        private FleeToHealer behaviour;
        
        public MoveToHealerState(FleeToHealer behaviour)
        {
            this.behaviour = behaviour;
        }
        
        public void Tick()
        {
            var distanceToHealer = (behaviour.transform.position - behaviour.healer.transform.position).magnitude;

            behaviour.transform.position = behaviour.transform.position;
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}