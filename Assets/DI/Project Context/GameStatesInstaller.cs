using System;
using System.Collections.Generic;
using States.Game_States;
using UnityEngine.Rendering;
using Zenject;

namespace DI
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var mainLevelState = new MainLevelState();
            var quitState = new QuitGameState();
            var mainMenuState = new MainMenuState(); 

            Container.Bind<QuitGameState>().FromInstance(quitState).AsSingle();
            Container.Bind<MainLevelState>().FromInstance(mainLevelState).AsSingle();
            Container.Bind<MainMenuState>().FromInstance(mainMenuState).AsSingle();
            
            Container.QueueForInject(quitState);
            Container.QueueForInject(mainLevelState);
            Container.QueueForInject(mainMenuState);
        }
    }
}