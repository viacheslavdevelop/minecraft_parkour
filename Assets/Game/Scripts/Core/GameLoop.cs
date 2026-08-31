using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.Data;
using Game.Scripts.Core.GameState;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Data;
using Game.Scripts.Player.Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Core
{
    public class GameLoop : LifetimeScope
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private GameConfig _gameConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.Register<GameStateMachine>(Lifetime.Singleton).As<IGameStateProvider>();
            builder.RegisterInstance(_playerConfig);
            builder.RegisterBuildCallback(resolver => resolver.Inject(_playerConfig));
            builder.Register<PlayerMoveInput>(Lifetime.Singleton).As<IMoveInput>();
            builder.Register<PlayerRotateInput>(Lifetime.Singleton).As<IRotateInput>();
        }
    }
}
