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

        public float MaxSpeed => _maxSpeed;
        public float Sensitivity { get; private set; }
        public float MaxPitch => _maxPitch;
        public float MinPitch => _minPitch;

        [Inject]
        public void Construct()
        {
            Sensitivity = Mathf.Clamp(_defaultSensitivity, _minSensitivity, _maxSensitivity);
        }
    }
}
