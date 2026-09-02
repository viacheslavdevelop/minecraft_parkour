using System;
using System.Collections.Generic;
using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.GameState;
using Game.Scripts.Gameplay.Abstractions;

namespace Game.Scripts.Gameplay
{
    public class TickExecutorPauseStopper : IPauseExecutionStopper, IDisposable
    {
        private readonly IReadOnlyList<ITickExecutable> _tickExecutables;
        private readonly IGameStateProvider _gameStateProvider;

        public TickExecutorPauseStopper(IReadOnlyList<ITickExecutable> tickExecutables, IGameStateProvider gameStateProvider)
        {
            _tickExecutables = tickExecutables;
            _gameStateProvider = gameStateProvider;

            _gameStateProvider.OnStateEntered += SetExecuting;
        }
        
        public void SetExecuting(GameStateType gameStateType)
        {
            foreach (var tickExecutable in _tickExecutables)
            {
                tickExecutable.IsExecuting = gameStateType == GameStateType.Playing;
            }
        }

        public void Dispose()
        {
            _gameStateProvider.OnStateEntered -= SetExecuting;
        }
    }
}