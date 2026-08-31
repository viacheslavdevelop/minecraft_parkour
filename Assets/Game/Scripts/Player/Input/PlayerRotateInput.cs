using Game.Scripts.GameInput.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player.Input
{
    public class PlayerRotateInput : IRotateInput
    {
        public Vector2 RotateAxis 
            => new(UnityEngine.Input.GetAxisRaw("Mouse X"), 
                UnityEngine.Input.GetAxisRaw("Mouse Y"));
    }
}