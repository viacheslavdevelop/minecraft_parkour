using System;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Components;

namespace Game.Scripts.Player.Input
{
    public class MobileJumpInput : IJumpInput, IDisposable
    {
        public bool IsJump => _isJumpButtonPressed;
        
        private readonly JumpButton _jumpButton;
        private bool _isJumpButtonPressed;

        public MobileJumpInput(JumpButton jumpButton)
        {
            _jumpButton = jumpButton;
            
            _jumpButton.OnPointerDown += JumpButtonPressed;
            _jumpButton.OnPointerUp += JumpButtonUnpressed;
        }

        private void JumpButtonPressed()
        {
            _isJumpButtonPressed = true;
        }

        private void JumpButtonUnpressed()
        {
            _isJumpButtonPressed = false;
        }
        
        public void Dispose()
        {
            _jumpButton.OnPointerDown -= JumpButtonPressed;
            _jumpButton.OnPointerUp -= JumpButtonUnpressed;
        }
    }
}