using States.Game_States;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class SceneStateManager : StateManager
    {
        private State currentState;
        public UnityEvent onStateChanged = new();

        public override State CurrentState => currentState;

        private void Start()
        {
            currentState = new PlayingState();
            SwitchState(currentState);
            onStateChanged?.Invoke();
        }

        private void Update()
        {
            // Debug.Log($"Scene state: {currentState.GetType().Name}");
            currentState.UpdateState(this);
        }

        public override void SwitchState(State state)
        {
            currentState.ExitState(this);
            currentState = state;
            currentState.EnterState(this);
            onStateChanged?.Invoke();
        }
    }
}