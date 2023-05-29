using System;
using States.Game_States;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace DefaultNamespace
{
    public class GameStateManager : StateManager
    {
        public UnityEvent onStateChanged;

        private void Awake()
        {
            onStateChanged = new UnityEvent();
        }
        
        private void Start()
        {
            CurrentState = new MainMenuState();
            SwitchState(CurrentState);
        }
        
        private void Update()
        {
            CurrentState.UpdateState(this);
        }

        public override void SwitchState(State state)
        {
            CurrentState.ExitState(this);
            CurrentState = state;
            CurrentState.EnterState(this);
            onStateChanged?.Invoke();
        }

        public override void ShutDown()
        {
            CurrentState.ExitState(this);
            CurrentState = null;
        }
    }
}