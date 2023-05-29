namespace States.Game_States
{
    public abstract class State
    {
        public abstract void EnterState(StateManager manager);

        public abstract void UpdateState(StateManager manager);

        public abstract void ExitState(StateManager manager);
    }
}