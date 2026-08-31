using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player.TickExecutors
{
    public class LateTickRotateExecutor : ILateTickExecutable
    {
        public bool IsExecuting { get; set; }

        private readonly IRotatable _rotatable;
        private readonly IRotateInput _rotateInput;
        private readonly float _sensitivity;

        public LateTickRotateExecutor(IRotatable rotatable, IRotateInput rotateInput, PlayerConfig playerConfig)
        {
            _rotatable = rotatable;
            _rotateInput = rotateInput;
            _sensitivity = playerConfig.Sensitivity;
        }
        
        public void LateTick()
        {
            _rotatable.Rotate(_rotateInput.RotateAxis, _sensitivity, Time.deltaTime);
        }
    }
}