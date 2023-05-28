using UI.Scripts;
using UnityEngine;
using Zenject;

namespace DI
{
    public class PauseMenuInstaller : MonoInstaller
    {
        [SerializeField] private PauseMenu pauseMenu;
        public override void InstallBindings()
        {
            var pauseMenuInstance = Container
                .InstantiatePrefabForComponent<PauseMenu>(pauseMenu);
            Container
                .Bind<PauseMenu>()
                .FromInstance(pauseMenuInstance)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(pauseMenu);
        }
    }
}