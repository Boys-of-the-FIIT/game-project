using System;
using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        
        private SceneStateManager sceneStateManager;
        private GameStateManager gameStateManager;
        private PlayingState playingState;
        private MainMenuState mainMenuState;

        [Inject]
        private void Construct(SceneStateManager sceneStateManager, GameStateManager gameStateManager,
            PlayingState playingState, MainMenuState mainMenuState)
        {
            this.sceneStateManager = sceneStateManager;
            this.gameStateManager = gameStateManager;
            this.playingState = playingState;
            this.mainMenuState = mainMenuState;
        }

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