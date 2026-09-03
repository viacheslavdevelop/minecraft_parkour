using Game.Scripts.GameInput.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player.Input
{
    public class MobileMoveInput : IMoveInput
    {
        private readonly Joystick _joystick;

        public MobileMoveInput(Joystick joystick)
        {
            _joystick = joystick;
        }
        
        public Vector2 MoveAxis
        {
            get
            {
                Vector2 axis = new(_joystick.Horizontal, _joystick.Vertical);
                return axis.sqrMagnitude > 1f ? axis.normalized : axis;
            }
        }
    }
}