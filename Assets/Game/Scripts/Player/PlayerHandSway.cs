using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Components;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerHandSway : IHandSway
    {
        private readonly IRotateInput _rotateInput;
        private readonly Transform _playerHand;
        
        private readonly float _stepAmount = 0.05f;
        private readonly float _maxStepDistance = 0.08f;
        private readonly float _smoothPosition = 8f;

        private readonly float _rotationAmount = 2f;
        private readonly float _maxRotationAngle = 5f;
        private readonly float _smoothRotation = 8f;

        private Vector3 _originLocalPosition;
        private Quaternion _originLocalRotation;

        public PlayerHandSway(PlayerHand playerHand, PlayerConfig playerConfig)
        {
            _playerHand = playerHand.transform;

            _stepAmount = playerConfig.StepAmount;
            _maxStepDistance = playerConfig.MaxStepDistance;
            _smoothPosition = playerConfig.SmoothPosition;
            _rotationAmount = playerConfig.RotationAmount;
            _maxRotationAngle = playerConfig.MaxRotationAngle;
            _smoothRotation = playerConfig.SmoothRotation;
        }
        
        public void Sway(Vector2 direction, float deltaTime)
        {
            float mouseX = -direction.x;
            float mouseY = -direction.y;

            Vector3 targetPosition = CalculatePositionSway(mouseX, mouseY);
            
            _playerHand.localPosition = Vector3.Lerp(
                _playerHand.localPosition, 
                _originLocalPosition + targetPosition, 
                deltaTime * _smoothPosition
            );

            Quaternion targetRotation = CalculateRotationSway(mouseX, mouseY);
            
            _playerHand.localRotation = Quaternion.Slerp(
                _playerHand.localRotation, 
                _originLocalRotation * targetRotation, 
                deltaTime * _smoothRotation
            );
        }
        
        private Vector3 CalculatePositionSway(float mouseX, float mouseY)
        {
            float moveX = Mathf.Clamp(mouseX * _stepAmount, -_maxStepDistance, _maxStepDistance);
            float moveY = Mathf.Clamp(mouseY * _stepAmount, -_maxStepDistance, _maxStepDistance);

            return new Vector3(moveX, moveY, 0f);
        }

        private Quaternion CalculateRotationSway(float mouseX, float mouseY)
        {
            float tiltX = Mathf.Clamp(mouseY * _rotationAmount, -_maxRotationAngle, _maxRotationAngle);
            float tiltY = Mathf.Clamp(mouseX * _rotationAmount, -_maxRotationAngle, _maxRotationAngle);

            return Quaternion.Euler(tiltX, tiltY, 0f);
        }
    }
}