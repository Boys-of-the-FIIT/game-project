using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : MonoBehaviour
{
    private GameStateManager gameStateManager;

    [Inject]
    private void Construct(GameStateManager manager)
    {
        gameStateManager = manager;
    }
    
    public void PlayGame()
    {
        gameStateManager.SwitchState(new MainLevelState());
    }

    public void QuitGame()
    {
        gameStateManager.SwitchState(new QuitGameState());
    }
}