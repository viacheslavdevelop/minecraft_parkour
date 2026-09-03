using Game.Scripts.GameInput.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player.Input
{
    public class DesktopJumpInput : IJumpInput
    {
        public bool IsJump => UnityEngine.Input.GetKey(KeyCode.Space);
    }
}