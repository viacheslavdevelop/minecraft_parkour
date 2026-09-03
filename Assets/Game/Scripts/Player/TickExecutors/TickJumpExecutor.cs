using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player.TickExecutors
{
    public class TickJumpExecutor : ITickExecutable
    {
        public bool IsExecuting { get; set; }
        
        private readonly IJumpable _jumpable;
        private readonly IJumpInput _jumpInput;

        public TickJumpExecutor(IJumpable jumpable, IJumpInput jumpInput)
        {
            _jumpable = jumpable;
            _jumpInput = jumpInput;

            IsExecuting = true;
        } 
        
        public void Tick()
        {
            if (IsExecuting)
            {
                _jumpable.Jump(_jumpInput.IsJump, Time.deltaTime);
            }
        }
    }
}