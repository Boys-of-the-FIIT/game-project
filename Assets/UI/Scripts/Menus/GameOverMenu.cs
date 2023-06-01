using System;
using DefaultNamespace;
using States.Game_States;
using TMPro;
using UnityEngine;
using Utils;
using Waves;
using Zenject;

namespace UI.Scripts
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private TextMeshProUGUI survivedTimeText;
        
        private Timer timer;
        private GameStateManager gameStateManager;
        private SceneStateManager sceneStateManager;
        private MainMenuState mainMenuState;
        private MainLevelState mainLevelState;
        private WaveManager waveManager;
        
        private void Awake()
        {
            GameObject.FindWithTag(Tags.Timer).TryGetComponent<Timer>(out timer);
        }

        [Inject]
        private void Construct(
            GameStateManager gameStateManager,
            SceneStateManager sceneStateManager,
            MainMenuState mainMenuState, 
            MainLevelState mainLevelState,
            WaveManager waveManager)
        {
            this.waveManager = waveManager;
            this.gameStateManager = gameStateManager;
            this.sceneStateManager = sceneStateManager;
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
            {
                canvas.gameObject.SetActive(true);
                survivedTimeText.text = $"You died on wave: {waveManager.CurrentWave.Name}";
            }
            else canvas.gameObject.SetActive(false);
        }
    }
}