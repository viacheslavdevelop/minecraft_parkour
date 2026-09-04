using UnityEngine;
using VContainer;

namespace Game.Scripts.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _maxSpeed;
        
        [Header("Rotation")]
        [SerializeField] private float _defaultSensitivity;
        [SerializeField] private float _minSensitivity;
        [SerializeField] private float _maxSensitivity;
        [SerializeField] private float _maxPitch;
        [SerializeField] private float _minPitch;

        [Header("Gravity")] 
        [SerializeField] private float _gravity;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius;

        [Header("Jumping")]
        [SerializeField] private float _jumpHeight;
        [SerializeField] private LayerMask _crownLayer;
        [SerializeField] private float _checkCrownRadius;
        [SerializeField] private float _downVelocity;
        
        [Header("Hand Sway")]
        [SerializeField] private float _stepAmount = 0.05f;
        [SerializeField] private float _maxStepDistance = 0.08f;
        [SerializeField] private float _smoothPosition = 8f;

        [SerializeField] private float _rotationAmount = 2f;
        [SerializeField] private float _maxRotationAngle = 5f;
        [SerializeField] private float _smoothRotation = 8f;

        public float MaxSpeed => _maxSpeed;
        public float Sensitivity { get; private set; }
        public float MaxPitch => _maxPitch;
        public float MinPitch => _minPitch;
        public float Gravity => _gravity;
        public LayerMask GroundLayer => _groundLayer;
        public float GroundCheckRadius => _groundCheckRadius;
        public float JumpHeight => _jumpHeight;
        public LayerMask CrownLayer => _crownLayer;
        public float CheckCrownRadius => _checkCrownRadius;
        public float DownVelocity => _downVelocity;
        public float StepAmount => _stepAmount;
        public float MaxStepDistance => _maxStepDistance;
        public float SmoothPosition => _smoothPosition;
        public float RotationAmount => _rotationAmount;
        public float MaxRotationAngle => _maxRotationAngle;
        public float SmoothRotation => _smoothRotation;

        [Inject]
        public void Construct()
        {
            Sensitivity = Mathf.Clamp(_defaultSensitivity, _minSensitivity, _maxSensitivity);
        }
    }
}
