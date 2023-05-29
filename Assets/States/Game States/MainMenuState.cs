using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace States.Game_States
{
    public class MainMenuState : State
    {
        [Inject] private DiContainer diContainer; 
        public override void EnterState(StateManager manager)
        {
            SceneManager.LoadScene(0);
        }

        public override void UpdateState(StateManager manager)
        {
           
        }

        public override void ExitState(StateManager manager)
        {
           
        }
    }
}