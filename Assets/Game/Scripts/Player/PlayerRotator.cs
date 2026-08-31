using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerRotator : IRotatable
    {
        private readonly Transform _playerHeadTransform;
        private readonly Transform _playerTransform;
        private readonly float _maxPitch;
        private readonly float _minPitch;
        private float _xRotation;
        private float _yRotation;

        public PlayerRotator(PlayerHead playerHead, PlayerConfig playerConfig, CharacterController characterController)
        {
            _playerHeadTransform = playerHead.transform;
            _maxPitch = playerConfig.MaxPitch;
            _minPitch = playerConfig.MinPitch;
            _playerTransform = characterController.transform;
        }
        
        public void Rotate(Vector2 direction, float sensitivity, float deltaTime)
        {
            //Debug.Log(sensitivity);
            _yRotation += direction.x * sensitivity * deltaTime;
            _xRotation -= direction.y * sensitivity * deltaTime;

            _xRotation = Mathf.Clamp(_xRotation, _minPitch, _maxPitch);

            _playerHeadTransform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            _playerTransform.localRotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}