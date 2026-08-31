using Game.Scripts.Player.Abstractions;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Player
{
    public class PlayerScope : LifetimeScope
    {
        [SerializeField] private CharacterController _characterController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_characterController);
            builder.Register<PlayerMover>(Lifetime.Singleton).As<IMovable>();
            builder.RegisterEntryPoint<TickMoveExecutor>();
        }
    }
}
