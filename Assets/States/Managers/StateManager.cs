using UnityEngine;

namespace States.Game_States
{
    public abstract class StateManager : MonoBehaviour
    {
        public abstract State CurrentState { get; }
        public abstract void SwitchState(State state);
    }
}