using Game.Scripts.Core.Abstractions;
using Game.Scripts.GameInput.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player.TickExecutors
{
    public class TickMoveExecutor : ITickExecutable
    {
        public bool IsExecuting { get; set; }
        
        private readonly IMovable _movable;
        private readonly IMoveInput _moveInput;
        private readonly float _maxMoveSpeed;

        public TickMoveExecutor(IMovable movable, IMoveInput moveInput, PlayerConfig playerConfig)
        {
            _movable = movable;
            _moveInput = moveInput;
            _maxMoveSpeed = playerConfig.MaxSpeed;
        }
        
        public void Tick()
        {
            _movable.Move(_moveInput.MoveAxis, Time.deltaTime, _maxMoveSpeed);
        }
    }
}