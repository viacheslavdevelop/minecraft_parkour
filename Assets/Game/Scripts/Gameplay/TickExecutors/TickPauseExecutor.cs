using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Gameplay.Abstractions;

namespace Game.Scripts.Gameplay.TickExecutors
{
    public class TickPauseExecutor : ITickExecutable
    {
        public bool IsExecuting { get; set; }
        
        private readonly IPauseInput _pauseInput;
        private readonly IPausable _pausable;

        public TickPauseExecutor(IPauseInput pauseInput, IPausable pausable)
        {
            _pauseInput = pauseInput;
            _pausable = pausable;
        }
        
        public void Tick()
        {
            if (!_pauseInput.PauseButtonPressed) return;
            
            if (_pausable.IsPause)
            {
                _pausable.Unpause();
            }
            else
            {
                _pausable.Pause();
            }
        }
    }
}