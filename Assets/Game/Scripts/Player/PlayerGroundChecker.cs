using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Components;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerGroundChecker : IGroundCheckable
    {
        private readonly Transform _playerFeet;
        private readonly LayerMask _groundLayer;
        private readonly float _groundCheckRadius;

        public PlayerGroundChecker(PlayerFeet playerFeet, PlayerConfig playerConfig)
        {
            _playerFeet = playerFeet.transform;
            _groundLayer = playerConfig.GroundLayer;
            _groundCheckRadius = playerConfig.GroundCheckRadius;
        }
        
        public bool IsOnGround()
        {
            return Physics.CheckSphere(
                _playerFeet.position,
                _groundCheckRadius,
                _groundLayer,
                QueryTriggerInteraction.Ignore);
        }
    }
}