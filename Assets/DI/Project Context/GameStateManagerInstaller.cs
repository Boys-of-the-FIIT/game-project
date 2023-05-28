using DefaultNamespace;
using States.Game_States;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameStateManagerInstaller : MonoInstaller
    {
        [SerializeField] private GameStateManager manager;
        
        public override void InstallBindings()
        {
            var managerInstance = Container
                .InstantiatePrefabForComponent<GameStateManager>(manager);
            
            Container
                .Bind<GameStateManager>()
                .FromInstance(managerInstance)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(manager);
        }
    }
}