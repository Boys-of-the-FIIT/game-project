using UnityEngine;

namespace States.Game_States
{
    public class PlayingState : State
    {
        public override void EnterState(StateManager manager)
        {

        }

        public override void UpdateState(StateManager manager)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                manager.SwitchState(new PausedState());
        }

        public override void ExitState(StateManager manager)
        {
         
        }
    }
}