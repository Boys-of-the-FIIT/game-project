using System;
using System.Collections;
using DefaultNamespace;
using States.Game_States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Waves;
using Zenject;

namespace UI.Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TimerText;

        private float currentTime;
        private IEnumerator timeCoroutine;
        private SceneStateManager sceneStateManager;
        private WaveManager waveManager;

        private string Text
        {
            get => TimerText.text;
            set => TimerText.text = value;
        }
        
        [Inject]
        private void Construct(WaveManager waveManager)
        {
            this.waveManager = waveManager;
        }

        private void Update()
        {
            currentTime = waveManager.CurrentTime;
            var formattedTime = TimeExtensions.FormatTime(currentTime);
            if (!waveManager.IsBreak)
                Text = $"{waveManager.CurrentWave.Name } {formattedTime}";
            else
                Text = $"Break time: {formattedTime}";
        }
    }
}