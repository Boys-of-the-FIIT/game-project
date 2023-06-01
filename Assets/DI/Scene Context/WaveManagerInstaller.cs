using UI.Scripts;
using UnityEngine;
using Waves;
using Zenject;

namespace DI.Scene_Context
{

    public class WaveManagerInstaller : MonoInstaller
    {
        [SerializeField] private WaveManager waveManager;
        
        public override void InstallBindings()
        {
            Container.Bind<WaveManager>()
                .FromInstance(waveManager)
                .AsCached()
                .NonLazy();
            Container.QueueForInject(waveManager);
        }
    }
}