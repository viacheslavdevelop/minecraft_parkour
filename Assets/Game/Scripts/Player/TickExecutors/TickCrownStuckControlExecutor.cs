using Game.Scripts.Core.Abstractions;
using Game.Scripts.Player.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player.TickExecutors
{
    public class TickCrownStuckControlExecutor : ITickExecutable
    {
        public bool IsExecuting { get; set; }

        private readonly ICrownStuckController _crownStuckController;

        public TickCrownStuckControlExecutor(ICrownStuckController crownStuckController)
        {
            _crownStuckController = crownStuckController;

            IsExecuting = true;
        }
        
        public void Tick()
        {
            if (IsExecuting)
            {
                _crownStuckController.ControlCrownStuck();
            }
        }
    }
}