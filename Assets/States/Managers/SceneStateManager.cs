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
            CurrentState = new PlayingState();
            SwitchState(CurrentState);
            onStateChanged?.Invoke();
        }

        private void Update()
        {
            CurrentState?.UpdateState(this);
        }
        
        public override void SwitchState(State state)
        {
            CurrentState?.ExitState(this);
            CurrentState = state;
            CurrentState?.EnterState(this);
            onStateChanged?.Invoke();
        }

        public override void ShutDown()
        {
            CurrentState?.ExitState(this);
            CurrentState = null;
        }
    }
}