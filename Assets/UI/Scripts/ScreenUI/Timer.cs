using System;
using System.Collections;
using DefaultNamespace;
using States.Game_States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TimerText;

        private float time;
        private IEnumerator timeCoroutine;
        private SceneStateManager sceneStateManager; 
        
        [Inject]
        private void Construct(SceneStateManager manager)
        {
            this.sceneStateManager = manager;
            sceneStateManager.onStateChanged.AddListener(HandleStateChange);
        }

        public void Start()
        {
            StartCoroutine(timeCoroutine);
        }

        public void Stop()
        {
            StopCoroutine(timeCoroutine);
        }

        private void Awake()
        {
            timeCoroutine = TimerCoroutine();
        }

        private IEnumerator TimerCoroutine()
        {
            time = 0;
            while (true)
            {
                time += Time.deltaTime;
                int minutes = Mathf.FloorToInt(time / 60F);
                int seconds = Mathf.FloorToInt(time % 60F);
                int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
                TimerText.text = minutes.ToString("00") + ":" + 
                                 seconds.ToString("00") + ":" +
                                 milliseconds.ToString("00");
                yield return null;
            }
        }

        private void HandleStateChange()
        {
            if (sceneStateManager.CurrentState is PlayingState) Start();
            else Stop();
        }
    }
}