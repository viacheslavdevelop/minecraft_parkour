using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Gameplay.Abstractions;

namespace Game.Scripts.Gameplay.TickExecutors
{
    public class TickPauseExecutor : ITickExecutable
    {
        public bool IsExecuting { get; set; }
        
        private readonly IGameStateProvider _gameStateProvider;
        private readonly IPauseInput _pauseInput;
        private readonly IPausable _pausable;
        
        public void Tick()
        {
            
        }
    }
}