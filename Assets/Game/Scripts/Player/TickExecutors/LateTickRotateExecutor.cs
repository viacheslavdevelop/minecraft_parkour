using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;

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

            IsExecuting = true;
        }
        
        public void LateTick()
        {
            if (IsExecuting)
            {
                _rotatable.Rotate(_rotateInput.RotateAxis, _sensitivity, 1);
            }
        }
    }
}