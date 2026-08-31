using Game.Scripts.Core.GameState;
using UnityEngine;

namespace Game.Scripts.Core.Data
{
    public class GameConfig
    {
        [SerializeField] private GameStateType _defaultGameState;

        public GameStateType DefaultGameStateType => _defaultGameState;
    }
}