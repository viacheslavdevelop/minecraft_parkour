using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Components;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerGravityApplier : IGravityApplier
    {
        private readonly CharacterController _characterController;
        private readonly Transform _playerFeet;
        private readonly LayerMask _groundLayer;
        private readonly float _groundCheckRadius;

        private float _verticalVelocity;

        public PlayerGravityApplier(
            CharacterController characterController,
            PlayerFeet playerFeet,
            PlayerConfig playerConfig)
        {
            _characterController = characterController;
            _playerFeet = playerFeet.transform;
            _groundLayer = playerConfig.GroundLayer;
            _groundCheckRadius = playerConfig.GroundCheckRadius;
        }

        public void DoGravity(float deltaTime, float gravity)
        {
            bool isGrounded = Physics.CheckSphere(
                _playerFeet.position,
                _groundCheckRadius,
                _groundLayer,
                QueryTriggerInteraction.Ignore);

            if (isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }

            _verticalVelocity += gravity * deltaTime;

            Vector3 gravityMovement =
                Vector3.up * (_verticalVelocity * deltaTime);

            _characterController.Move(gravityMovement);
        }
    }
}