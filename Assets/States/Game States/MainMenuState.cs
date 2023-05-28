using UnityEngine.SceneManagement;

namespace States.Game_States
{
    public class MainMenuState : State
    {
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