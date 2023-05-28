using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [Inject] private GameStateManager manager;
    
    public void PlayGame()
    {
        manager.SwitchState(new MainLevelState());
    }

    public void QuitGame()
    {
        manager.SwitchState(new QuitGameState());
    }
}