using UnityEngine;

namespace States.Game_States
{
    public abstract class StateManager : MonoBehaviour
    {
        private protected State currentState;
        public State CurrentState => currentState;
        public abstract void SwitchState(State state);
        public abstract void ShutDown();
    }
}