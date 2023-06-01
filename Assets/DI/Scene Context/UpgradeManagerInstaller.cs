using UnityEngine;
using Upgrades;
using Zenject;

namespace DI.Scene_Context
{
    public class UpgradeManagerInstaller : MonoInstaller
    {
        [SerializeField] private UpgradeManager upgradeManager;

        public override void InstallBindings()
        {
            var upgradeManagerInstance = Container
                .InstantiatePrefabForComponent<UpgradeManager>(upgradeManager);

            Container.Bind<UpgradeManager>()
                .FromInstance(upgradeManagerInstance)
                .AsSingle()
                .NonLazy();
            Container.QueueForInject(upgradeManager);
        }
    }
}