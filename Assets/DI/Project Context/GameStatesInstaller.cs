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
            new List<State>()
            {
                new MainLevelState(),
                new QuitGameState(),
                new MainMenuState(),
            }.ForEach(state =>
            {
                Container.Bind(state.GetType()).FromInstance(state).AsSingle();
                Container.QueueForInject(state);
            });
        }
    }
}