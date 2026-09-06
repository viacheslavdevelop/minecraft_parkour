using Game.Scripts.Gameplay.Data;
using UnityEngine;
using VContainer;
using YG;

namespace Game.Scripts.Gameplay.Components
{
    public class Level : MonoBehaviour
    {
        public LevelData LevelData => _levelData;
        
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private EndPoint _endPoint;
        [SerializeField] private LevelData _levelData;

        private CharacterController _player;
        private IObjectResolver _objectResolver;

        [Inject]
        public void Construct(CharacterController player, IObjectResolver objectResolver)
        {
            _player = player;

            _player.enabled = false;
            _player.transform.position = _spawnPoint.position;
            _player.enabled = true;

            _objectResolver = objectResolver;
            
            _objectResolver.Inject(_endPoint);
        }
    }
}