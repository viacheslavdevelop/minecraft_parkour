using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Player.Input
{
    public class MobileRotateInput : IRotateInput
    {
        private readonly TouchPanel _touchPanel;

        public MobileRotateInput(TouchPanel touchPanel)
        {
            _touchPanel = touchPanel;
        }

        public Vector2 RotateAxis => _touchPanel.TouchInput;
    }
}