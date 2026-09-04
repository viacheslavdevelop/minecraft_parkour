using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Input;
using VContainer;
using VContainer.Unity;
using YG;

namespace Game.Scripts.Gameplay
{
    public class InputSelector : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            if (YG2.envir.)
            builder.Register<MobileMoveInput>(Lifetime.Singleton).As<IMoveInput>();
            builder.Register<MobileRotateInput>(Lifetime.Singleton).As<IRotateInput>();
            builder.Register<MobileJumpInput>(Lifetime.Singleton).As<IJumpInput>();
            
            //builder.Register<PlayerMoveInput>(Lifetime.Singleton).As<IMoveInput>();
            //builder.Register<PlayerRotateInput>(Lifetime.Singleton).As<IRotateInput>();
            //builder.Register<DesktopJumpInput>(Lifetime.Singleton).As<IJumpInput>();
        }
    }
}