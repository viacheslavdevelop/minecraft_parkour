using System;
using System.Collections.Generic;
using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.GameState;
using Game.Scripts.Gameplay.Abstractions;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class LateTickExecutorPauseStopper : IPauseExecutionStopper, IDisposable
    {
        private readonly IReadOnlyList<ILateTickExecutable> _lateTickExecutables;
        private readonly IGameStateProvider _gameStateProvider;

        public LateTickExecutorPauseStopper(IReadOnlyList<ILateTickExecutable> lateTickExecutables, IGameStateProvider gameStateProvider)
        {
            _lateTickExecutables = lateTickExecutables;
            _gameStateProvider = gameStateProvider;

            _gameStateProvider.OnStateEntered += SetExecuting;
        }
        
        public void SetExecuting(GameStateType gameStateType)
        {
            foreach (var lateTickExecutable in _lateTickExecutables)
            {
                lateTickExecutable.IsExecuting = gameStateType == GameStateType.Playing;
            }
        }

        public void Dispose()
        {
            _gameStateProvider.OnStateEntered -= SetExecuting;
        }
    }
}