using Game.Scripts.Player.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerGravityApplier : IGravityApplier
    {
        private readonly CharacterController _characterController;
        private readonly IGroundCheckable _groundCheckable;

        private float _verticalVelocity;
        
        public PlayerGravityApplier(CharacterController characterController, IGroundCheckable groundCheckable)
        {
            _characterController = characterController;
            _groundCheckable = groundCheckable;
        }

        public void DoGravity(float deltaTime, float gravity)
        {
            if (_groundCheckable.IsOnGround() && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }

            _verticalVelocity += gravity * deltaTime;

            Vector3 gravityMovement =
                Vector3.up * (_verticalVelocity * deltaTime);

            _characterController.Move(gravityMovement);
        }
        
        public void SetVerticalVelocity(float verticalVelocity)
        {
            _verticalVelocity = verticalVelocity;
        }
    }
}