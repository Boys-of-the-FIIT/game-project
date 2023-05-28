using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class GameOverScreen : MonoBehaviour
    {
        [Inject] private GameStateManager gameStateManager;
        [Inject] private PlayingState playingState;
        [Inject] private MainMenuState mainMenuState;
        [Inject] private MainLevelState mainLevelState;

        [SerializeField] private Canvas canvas;
        
        private void Start()
        {
            canvas.gameObject.SetActive(false);
            gameStateManager.onStateChanged.AddListener(HandleStateChange);
        }
        
        public void Retry()
        {
            gameStateManager.SwitchState(mainLevelState);
        }

        public void EnterMainMenu()
        {
            gameStateManager.SwitchState(mainMenuState);
        }

        private void HandleStateChange()
        {
            Debug.Log("Handle State Change Invoked");
            if (gameStateManager.CurrentState is GameOverState)
                canvas.gameObject.SetActive(true);
            else
                canvas.gameObject.SetActive(false);
        }
    }
}