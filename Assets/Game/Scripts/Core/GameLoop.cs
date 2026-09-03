using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.Data;
using Game.Scripts.Core.GameState;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Gameplay;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Input;
using Game.Scripts.Gameplay.TickExecutors;
using Game.Scripts.Player.Components;
using Game.Scripts.Player.Data;
using Game.Scripts.Player.Input;
using Game.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Core
{
    public class GameLoop : LifetimeScope
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JumpButton _jumpButton;
        [SerializeField] private TouchPanel _touchPanel;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_joystick);
            builder.RegisterInstance(_jumpButton);
            builder.RegisterInstance(_gameConfig);
            builder.RegisterInstance(_touchPanel);
            
            builder.Register<GameStateMachine>(Lifetime.Singleton).As<IGameStateProvider>();
            builder.Register<DesktopPauseInput>(Lifetime.Singleton).As<IPauseInput>();
            builder.Register<GamePauser>(Lifetime.Singleton).As<IPausable>();
            
            builder.RegisterInstance(_playerConfig);
            
            builder.RegisterEntryPoint<TickPauseExecutor>();
            builder.RegisterBuildCallback(resolver => resolver.Inject(_playerConfig));
            
            //builder.Register<PlayerMoveInput>(Lifetime.Singleton).As<IMoveInput>();
            builder.Register<MobileMoveInput>(Lifetime.Singleton).As<IMoveInput>();
            //builder.Register<PlayerRotateInput>(Lifetime.Singleton).As<IRotateInput>();
            builder.Register<MobileRotateInput>(Lifetime.Singleton).As<IRotateInput>();
            //builder.Register<DesktopJumpInput>(Lifetime.Singleton).As<IJumpInput>();
            builder.Register<MobileJumpInput>(Lifetime.Singleton).As<IJumpInput>();
        }
    }
}
