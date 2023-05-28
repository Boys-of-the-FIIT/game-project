using Player;
using UnityEngine;
using Zenject;

namespace DI
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerEntity player;
        public override void InstallBindings()
        {
            Container.Bind<PlayerEntity>()
                .FromInstance(player)
                .AsSingle()
                .NonLazy();
        
            Container.QueueForInject(player);
        }
    }
}