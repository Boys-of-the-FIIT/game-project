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
            currentState = new MainMenuState();
            SwitchState(currentState);
        }
        
        private void Update()
        {
            currentState.UpdateState(this);
        }

        public override void SwitchState(State state)
        {
            currentState.ExitState(this);
            currentState = state;
            currentState.EnterState(this);
            onStateChanged?.Invoke();
        }

        public override void ShutDown()
        {
            currentState.ExitState(this);
            currentState = null;
        }
    }
}