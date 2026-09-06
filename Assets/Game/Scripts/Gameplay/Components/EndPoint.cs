using System;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Data;
using Game.Scripts.Player.Components;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Gameplay.Components
{
    [RequireComponent(typeof(SphereCollider))]
    public class EndPoint : MonoBehaviour
    {
        private IEndLevelHandler _endLevelHandler;
        private LevelData _levelData;

        [Inject]
        public void Construct(IEndLevelHandler endLevelHandler, ILevelProvider levelProvider)
        {
            _endLevelHandler = endLevelHandler;
            _levelData = levelProvider.LevelStruct.LevelData;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerGameObject>() != null)
            {
                _endLevelHandler.HandleEndLevel(_levelData.LevelID);
            }
        }
    }
}