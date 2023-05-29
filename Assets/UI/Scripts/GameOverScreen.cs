using System;
using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class GameOverScreen : MonoBehaviour
    {
        [Inject] private GameStateManager gameStateManager;
        [Inject] private SceneStateManager sceneStateManager;
        [Inject] private MainMenuState mainMenuState;
        [Inject] private MainLevelState mainLevelState;

        [SerializeField] private Canvas canvas;
        
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