using UnityEngine;
using Waves;
using Zenject;

namespace DI.Scene_Context
{
    public class EntityWaveSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EntityWaveSpawner entityWaveSpawner;
        
        public override void InstallBindings()
        {
            var entityWaveSpawnerInstance = Container
                .InstantiatePrefabForComponent<EntityWaveSpawner>(entityWaveSpawner);
            Container
                .Bind<EntityWaveSpawner>()
                .FromInstance(entityWaveSpawnerInstance)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(entityWaveSpawner);
        }
    }
}