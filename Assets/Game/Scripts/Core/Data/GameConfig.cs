using System.Collections.Generic;
using Game.Scripts.Core.GameState;
using Game.Scripts.Gameplay.Components;
using UnityEngine;

namespace Game.Scripts.Core.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [Header("Gameplay")]
        [SerializeField] private string _mainMenuSceneName;
        [SerializeField] private string _gameplaySceneName;
        [SerializeField] private GameStateType _defaultGameState;

        [Header("Saves")]
        [SerializeField] private float _debounceSeconds = 0.5f;
        [SerializeField] private float _maxDelaySeconds = 5f;

        [Header("Levels")] 
        [SerializeField] private List<Level> _levels;

        public string MainMenuSceneName => _mainMenuSceneName;
        public string GameplaySceneName => _gameplaySceneName;
        public GameStateType DefaultGameStateType => _defaultGameState;
        public float DebounceSeconds => _debounceSeconds;
        public float MaxDelaySeconds => _maxDelaySeconds;
        public List<Level> Levels => _levels;
    }
}