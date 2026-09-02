using Game.Scripts.Core.Abstractions;
using Game.Scripts.Player.Abstractions;
using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player.TickExecutors
{
    public class TickGravityExecutor : ITickExecutable
    {
        public bool IsExecuting { get; set; }

        private readonly IGravityApplier _gravityApplier;
        private readonly float _gravity;

        public TickGravityExecutor(PlayerConfig playerConfig, IGravityApplier gravityApplier)
        {
            _gravity = playerConfig.Gravity;
            _gravityApplier = gravityApplier;

            IsExecuting = true;
        }
        
        public void Tick()
        {
            if (IsExecuting)
            {
                _gravityApplier.DoGravity(Time.deltaTime, _gravity);        
            }   
        }
    }
}