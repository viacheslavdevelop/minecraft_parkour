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
        public LevelData LevelData { get; set; }
        
        private IEndLevelHandler _endLevelHandler;

        [Inject]
        public void Construct(IEndLevelHandler endLevelHandler)
        {
            _endLevelHandler = endLevelHandler;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerGameObject>() != null)
            {
                _endLevelHandler.HandleEndLevel(LevelData.LevelID);
            }
        }
    }
}