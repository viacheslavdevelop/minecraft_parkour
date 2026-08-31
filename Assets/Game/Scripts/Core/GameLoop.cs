using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Core
{
    public class GameLoop : LifetimeScope
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _characterTransform;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerConfig);
            builder.RegisterInstance(_characterController);
            builder.RegisterInstance(_characterTransform);
            builder.Register<PlayerMoveInput>(Lifetime.Singleton).As<IMoveInput>();
            builder.Register<PlayerMover>(Lifetime.Singleton).As<IMovable>();
            builder.RegisterEntryPoint<TickMoveExecutor>();
        }
    }
}
