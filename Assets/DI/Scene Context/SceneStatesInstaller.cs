using States.Game_States;
using Zenject;

namespace DI.Scene_Context
{
    public class SceneStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameOverState = new GameOverState();
            var playingState = new PlayingState();
            var pausedState = new PausedState();

            Container.Bind<GameOverState>().FromInstance(gameOverState).AsSingle();
            Container.Bind<PlayingState>().FromInstance(playingState).AsSingle();
            Container.Bind<PausedState>().FromInstance(pausedState).AsSingle();
            
            Container.QueueForInject(gameOverState);
            Container.QueueForInject(playingState);        
            Container.QueueForInject(pausedState);
        }
    }
}