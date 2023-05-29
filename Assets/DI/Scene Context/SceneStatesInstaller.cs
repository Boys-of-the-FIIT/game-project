using System;
using System.Collections.Generic;
using States.Game_States;
using Zenject;

namespace DI.Scene_Context
{
    public class SceneStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            new List<State>()
            {
                new GameOverState(),
                new PlayingState(),
                new PausedState(),
            }.ForEach(state =>
            {
                Container.Bind(state.GetType()).FromInstance(state).AsSingle();
                Container.QueueForInject(state);
            });
        }
    }
}