using System;
using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class GameOverScreen : MonoBehaviour
    {
        private GameStateManager gameStateManager;
        private SceneStateManager sceneStateManager;
        private MainMenuState mainMenuState;
        private MainLevelState mainLevelState;

        [SerializeField] private Canvas canvas;

        [Inject]
        private void Construct(GameStateManager gameStateManager, SceneStateManager sceneStateManager,
            MainMenuState mainMenuState, MainLevelState mainLevelState)
        {
            this.gameStateManager= gameStateManager;
            this.sceneStateManager= sceneStateManager;
            this.mainMenuState= mainMenuState;
            this.mainLevelState= mainLevelState;
        }

        private void Start()
        {
            canvas.gameObject.SetActive(true);
            sceneStateManager?.onStateChanged.AddListener(HandleStateChange);
        }

        public void Retry()
        {
            sceneStateManager.ShutDown();
            gameStateManager.SwitchState(mainLevelState);
        }

        public void EnterMainMenu()
        {
            sceneStateManager.ShutDown();
            gameStateManager.SwitchState(mainMenuState);
        }

        private void HandleStateChange()
        {
            if (sceneStateManager.CurrentState is GameOverState)
                canvas.gameObject.SetActive(true);
            else
                canvas.gameObject.SetActive(false);
        }
    }
}