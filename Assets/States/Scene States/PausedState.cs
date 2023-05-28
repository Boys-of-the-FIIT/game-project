using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace States.Game_States
{
    public class PausedState : State
    {
        public override void EnterState(StateManager manager)
        {
            Time.timeScale = 0;
        }

        public override void UpdateState(StateManager manager)
        {      
            if (Input.GetKeyDown(KeyCode.Escape))
                manager.SwitchState(new PlayingState());
        }

        public override void ExitState(StateManager manager)
        {
            Time.timeScale = 1;
        }
    }
}