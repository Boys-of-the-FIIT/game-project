using States.Game_States;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class SceneStateManager : StateManager
    {
        public UnityEvent onStateChanged;

        private void Awake()
        {
            onStateChanged = new UnityEvent();
        }
        
        private void Start()
        {
            currentState = new PlayingState();
            SwitchState(currentState);
            onStateChanged?.Invoke();
        }

        private void Update()
        {
            currentState?.UpdateState(this);
        }
        
        public override void SwitchState(State state)
        {
            currentState?.ExitState(this);
            currentState = state;
            currentState?.EnterState(this);
            onStateChanged?.Invoke();
        }

        public override void ShutDown()
        {
            currentState?.ExitState(this);
            currentState = null;
        }
    }
}