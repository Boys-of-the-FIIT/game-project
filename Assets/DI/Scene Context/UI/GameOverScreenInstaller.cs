using UI.Scripts;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameOverScreenInstaller : MonoInstaller
    {
        [SerializeField] private GameOverScreen gameOverScreen;
        public override void InstallBindings()
        {
            var pauseMenuInstance = Container
                .InstantiatePrefabForComponent<GameOverScreen>(gameOverScreen);
            Container
                .Bind<GameOverScreen>()
                .FromInstance(pauseMenuInstance)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(gameOverScreen);
        }
    }
}