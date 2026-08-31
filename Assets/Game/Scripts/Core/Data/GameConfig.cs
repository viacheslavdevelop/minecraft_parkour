using Game.Scripts.Core.GameState;
using UnityEngine;

namespace Game.Scripts.Core.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private GameStateType _defaultGameState;

        public GameStateType DefaultGameStateType => _defaultGameState;
    }
}