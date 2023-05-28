using System.Net.Mime;
using DefaultNamespace;
using UnityEngine;

namespace States.Game_States
{
    public class QuitGameState : State
    {
        public override void EnterState(StateManager manager)
        {
            Application.Quit();
        }

        public override void UpdateState(StateManager manager)
        {
            
        }

        public override void ExitState(StateManager manager)
        {
           
        }
    }
}