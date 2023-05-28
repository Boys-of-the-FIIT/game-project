using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace DI.Scene_Context
{
    public class SceneStateManagerInstaller : MonoInstaller
    {
        [SerializeField] private SceneStateManager manager;
        public override void InstallBindings()
        {
            Container
                .Bind<SceneStateManager>()
                .FromInstance(manager)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(manager);
        }
    }
}