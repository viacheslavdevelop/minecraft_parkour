using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Components;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class CrownStuckController : ICrownStuckController
    {
        private readonly IGravityApplier _gravityApplier;
        private readonly Transform _playerCrown;
        private readonly LayerMask _crownLayer;
        private readonly float _crownCheckRadius;
        private readonly float _downVelocity;

        private bool _isStuck;

        public CrownStuckController(PlayerCrown playerCrown, IGravityApplier gravityApplier, PlayerConfig playerConfig)
        {
            _playerCrown = playerCrown.transform;
            _gravityApplier = gravityApplier;

            _crownLayer = playerConfig.CrownLayer;
            _crownCheckRadius = playerConfig.CheckCrownRadius;
            _downVelocity = playerConfig.DownVelocity;
        }
        
        public void ControlCrownStuck()
        {
            bool isCrownStuck = Physics.CheckSphere(
                _playerCrown.position,
                _crownCheckRadius,
                _crownLayer,
                QueryTriggerInteraction.Ignore);
            
            switch (isCrownStuck)
            {
                case true when !_isStuck:
                    _gravityApplier.SetVerticalVelocity(_downVelocity);
                    _isStuck = true;
                    return;
                case false:
                    _isStuck = false;
                    break;
            }
        }
    }
}