using Game.Scripts.Core.GameState;
using UnityEngine;

namespace Game.Scripts.Core.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [Header("Gameplay")]
        [SerializeField] private string _mainMenuSceneName;
        [SerializeField] private GameStateType _defaultGameState;

        [Header("Saves")]
        [SerializeField] private float _debounceSeconds = 0.5f;
        [SerializeField] private float _maxDelaySeconds = 5f;

        public string MainMenuSceneName => _mainMenuSceneName;
        public GameStateType DefaultGameStateType => _defaultGameState;
        public float DebounceSeconds => _debounceSeconds;
        public float MaxDelaySeconds => _maxDelaySeconds;
    }
}