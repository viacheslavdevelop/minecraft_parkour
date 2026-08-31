using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player;
using Game.Scripts.Player.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Core
{
    public class GameLoop : LifetimeScope
    {
        [SerializeField] private PlayerConfig _playerConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerConfig);
            builder.Register<PlayerMoveInput>(Lifetime.Singleton).As<IMoveInput>();
        }
    }
}
