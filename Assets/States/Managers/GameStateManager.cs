using System;
using States.Game_States;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace DefaultNamespace
{
    public class GameStateManager : StateManager
    {
        private State currentState;
        public UnityEvent onStateChanged = new();
        
        public override State CurrentState => currentState;
        
        private void Start()
        {
            currentState = new MainMenuState();
            SwitchState(currentState);
        }

        private void Update()
        {
            // Debug.Log($"Game state: {currentState.GetType().Name}");
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