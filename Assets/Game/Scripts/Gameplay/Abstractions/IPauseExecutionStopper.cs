using Game.Scripts.Core.GameState;

namespace Game.Scripts.Gameplay.Abstractions
{
    public interface IPauseExecutionStopper
    {
        void SetExecuting(GameStateType gameStateType);
    }
}