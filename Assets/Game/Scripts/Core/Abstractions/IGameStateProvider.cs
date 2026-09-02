using System;
using Game.Scripts.Core.GameState;

namespace Game.Scripts.Core.Abstractions
{
    public interface IGameStateProvider
    {
        event Action<GameStateType> OnStateEntered;
        event Action<GameStateType> OnStateExited;
    
        GameStateType CurrentGameState { get; }

        void SetupState(GameStateType newState);
    }
}