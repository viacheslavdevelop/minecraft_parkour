using Game.Scripts.Player.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerMover : IMovable
    {
        private CharacterController _characterController;
        private Transform _characterTransform;

        private PlayerMover(CharacterController characterController, Transform characterTransform)
        {
            _characterController = characterController;
            _characterTransform = characterTransform;
        }
        
        public void Move(Vector2 direction, float deltaTime, float moveSpeed)
        {
            Vector3 moveDirection = _characterTransform.forward * direction.y + _characterTransform.right * direction.x;

            _characterController.Move(moveSpeed * deltaTime * moveDirection);
        }
    }
}