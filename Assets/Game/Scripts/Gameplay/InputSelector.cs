using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Gameplay.Components;
using Game.Scripts.Player;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using YG;

namespace Game.Scripts.Gameplay
{
    public class InputSelector : LifetimeScope
    {
        [SerializeField] private MobileCanvas _mobileCanvas;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_mobileCanvas);
            
            builder.RegisterEntryPoint<MobileCanvasHider>();
            
            if (YG2.envir.device == YG2.Device.Mobile || YG2.envir.device == YG2.Device.Tablet)
            {
                builder.Register<MobileMoveInput>(Lifetime.Singleton).As<IMoveInput>();
                builder.Register<MobileRotateInput>(Lifetime.Singleton).As<IRotateInput>();
                builder.Register<MobileJumpInput>(Lifetime.Singleton).As<IJumpInput>();
                builder.Register<MobileCursorController>(Lifetime.Singleton).As<ICursorController>();
            }
            else
            {
                builder.Register<PlayerMoveInput>(Lifetime.Singleton).As<IMoveInput>();
                builder.Register<PlayerRotateInput>(Lifetime.Singleton).As<IRotateInput>();
                builder.Register<DesktopJumpInput>(Lifetime.Singleton).As<IJumpInput>();
                builder.Register<DesktopCursorController>(Lifetime.Singleton).As<ICursorController>();
            }
            
            builder.RegisterBuildCallback(resolver => resolver.Resolve<ICursorController>());
        }
    }
}