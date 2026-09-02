using Game.Scripts.Gameplay;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.TickExecutors;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Player
{
    public class PlayerScope : LifetimeScope
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerHead _playerHead;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_characterController);
            builder.RegisterInstance(_playerHead);
            builder.Register<PlayerMover>(Lifetime.Singleton).As<IMovable>();
            builder.Register<PlayerRotator>(Lifetime.Singleton).As<IRotatable>();
            builder.RegisterEntryPoint<TickMoveExecutor>();
            builder.RegisterEntryPoint<LateTickRotateExecutor>();
            builder.Register<DesktopCursorController>(Lifetime.Singleton).As<ICursorController>();
            builder.RegisterBuildCallback(resolver => resolver.Resolve<ICursorController>());
            
            builder.Register<LateTickExecutorPauseStopper>(Lifetime.Singleton)
                .As<IPauseExecutionStopper>()
                .AsSelf();

            builder.Register<TickExecutorPauseStopper>(Lifetime.Singleton)
                .As<IPauseExecutionStopper>()
                .AsSelf();

            builder.RegisterBuildCallback(resolver =>
            {
                resolver.Resolve<LateTickExecutorPauseStopper>();
                resolver.Resolve<TickExecutorPauseStopper>();
            });
        }
    }
}
