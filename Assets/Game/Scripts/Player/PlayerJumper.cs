using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerJumper : IJumpable
    {
        private readonly IGravityApplier _gravityApplier;
        private readonly IGroundCheckable _groundCheckable;
        private readonly float _jumpHeight;
        private readonly float _gravity;
        private float _velocity;

        private PlayerJumper(IGravityApplier gravityApplier, IGroundCheckable groundCheckable, PlayerConfig playerConfig)
        {
            _groundCheckable = groundCheckable;
            _gravityApplier = gravityApplier;
            _jumpHeight = playerConfig.JumpHeight;
            _gravity = playerConfig.Gravity;
        }
        
        public void Jump(bool isJump, float deltaTime)
        {
            if (_groundCheckable.IsOnGround() && isJump)
            {
                float jumpVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
                _gravityApplier.SetVerticalVelocity(jumpVelocity);
            }
        }
    }
}