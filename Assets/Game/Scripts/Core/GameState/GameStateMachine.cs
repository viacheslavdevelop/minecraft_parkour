using System;
using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.Data;

namespace Game.Scripts.Core.GameState
{
    public class GameStateMachine : IGameStateProvider
    {
        public event Action<GameStateType> OnStateEntered;
        public event Action<GameStateType> OnStateExited;
    
        public GameStateType CurrentGameState { get; private set; }
    
        public GameStateMachine(GameConfig gameConfig)
        {
            CurrentGameState = gameConfig.DefaultGameStateType;
        }

        public void SetupState(GameStateType newState)
        {
            if (CurrentGameState == newState) return;

            OnStateExited?.Invoke(CurrentGameState);
            
            CurrentGameState = newState;
        
            OnStateEntered?.Invoke(CurrentGameState);
        }
    }
}