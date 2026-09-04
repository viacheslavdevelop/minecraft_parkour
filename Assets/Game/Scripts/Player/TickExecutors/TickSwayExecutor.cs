using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player.TickExecutors
{
    public class TickSwayExecutor : ITickExecutable 
    {
        public bool IsExecuting { get; set; }

        private readonly IHandSway _handSway;
        private readonly IRotateInput _rotateInput;
        
        public TickSwayExecutor(IHandSway handSway, IRotateInput rotateInput, PlayerConfig playerConfig)
        {
            _handSway = handSway;
            _rotateInput = rotateInput;
            
            IsExecuting = true;
        }
        
        public void Tick()
        {
            if (IsExecuting)
            {
                _handSway.Sway(_rotateInput.RotateAxis, Time.deltaTime);
            }
        }
    }
}