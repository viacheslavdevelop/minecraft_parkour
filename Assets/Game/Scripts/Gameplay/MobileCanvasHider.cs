using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;
using VContainer.Unity;
using YG;

namespace Game.Scripts.Gameplay
{
    public class MobileCanvasHider : IMobileCanvasHider, IStartable
    {
        private readonly MobileCanvas _mobileCanvas;

        public MobileCanvasHider(MobileCanvas mobileCanvas)
        {
            _mobileCanvas = mobileCanvas;
        }
        
        public void Start()
        {
            HandleCanvasVisibility();
        }
        
        public void HandleCanvasVisibility()
        {
            _mobileCanvas.gameObject.SetActive(!YG2.envir.isDesktop);
        }
    }
}