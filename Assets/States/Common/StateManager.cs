using UnityEngine;

namespace States.Game_States
{
    public abstract class StateManager : MonoBehaviour
    {
        private State currentState;

        public State CurrentState
        {
            get => currentState;
            protected internal set => currentState = value;
        }

        public abstract void SwitchState(State state);
        public abstract void ShutDown();
    }
}