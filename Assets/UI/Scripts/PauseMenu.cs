using System;
using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        [Inject] private SceneStateManager sceneStateManager;
        [Inject] private GameStateManager gameStateManager;
        [Inject] private PlayingState playingState;
        [Inject] private MainMenuState mainMenuState;

        [SerializeField] private Canvas canvas;
        
        public void Resume()
        {
            sceneStateManager.SwitchState(playingState);
        }

        public void EnterMainMenu()
        {
            sceneStateManager.ShutDown();
            gameStateManager.SwitchState(mainMenuState);
        }
        
        private void Start()
        {
            canvas.gameObject.SetActive(false);
            sceneStateManager.onStateChanged?.AddListener(HandleStateChange);
        }

        private void HandleStateChange()
        {
            if (sceneStateManager.CurrentState is PausedState)
                canvas.gameObject.SetActive(true);
            else
                canvas.gameObject.SetActive(false);
        }
    }
}