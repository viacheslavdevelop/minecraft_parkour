using Game.Scripts.GameInput.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player.Input
{
    public class PlayerMoveInput : IMoveInput
    {
        public Vector2 MoveAxis
        {
            get
            {
                Vector2 axis = new(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
                return axis.sqrMagnitude > 1f ? axis.normalized : axis;
            }
        }
    }
}