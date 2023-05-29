using System;
using System.Collections.Generic;
using System.ComponentModel;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace States.Game_States
{
    public class MainLevelState : State
    {
        public override void EnterState(StateManager manager)
        {
            SceneManager.LoadSceneAsync(1);
        }

        public override void UpdateState(StateManager manager)
        {

        }

        public override void ExitState(StateManager manager)
        {
            
        }
    }
}