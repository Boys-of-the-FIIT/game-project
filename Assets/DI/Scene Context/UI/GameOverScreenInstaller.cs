using UI.Scripts;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameOverScreenInstaller : MonoInstaller
    {
        [SerializeField] private GameOverMenu gameOverMenu;
        public override void InstallBindings()
        {
            var pauseMenuInstance = Container
                .InstantiatePrefabForComponent<GameOverMenu>(gameOverMenu);
            Container
                .Bind<GameOverMenu>()
                .FromInstance(pauseMenuInstance)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(gameOverMenu);
        }
    }
}