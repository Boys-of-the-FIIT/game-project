using UnityEngine;
using Zenject;

namespace DI
{
    public class MainCameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var camera = Camera.main;
            Container.Bind<Camera>()
                .FromInstance(camera)
                .AsSingle()
                .NonLazy();
        
            Container.QueueForInject(camera);
        }
    }
}
