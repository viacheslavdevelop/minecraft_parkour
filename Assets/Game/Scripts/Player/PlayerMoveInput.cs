using Game.Scripts.GameInput.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerMoveInput : IMoveInput
    {
        public Vector2 MoveAxis
        {
            get
            {
                Vector2 axis = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                return axis.sqrMagnitude > 1f ? axis.normalized : axis;
            }
        }
    }
}