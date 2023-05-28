using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States.Game_States
{
    public class GameOverState : State
    {
        public override void EnterState(StateManager manager)
        {
            Time.timeScale = 0;
        }   

        public override void UpdateState(StateManager manager)
        {

        }

        public override void ExitState(StateManager manager)
        {
            Time.timeScale = 1;
        }
    }
}