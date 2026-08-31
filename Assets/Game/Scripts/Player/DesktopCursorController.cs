using System;
using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.GameState;
using Game.Scripts.Player.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class DesktopCursorController : ICursorController, IDisposable
    {
        public bool IsShowed { get; private set; }

        private IGameStateProvider _gameStateProvider;

        public DesktopCursorController(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;

            _gameStateProvider.OnStateEntered += SelectCursorMode;
            SelectCursorMode(_gameStateProvider.CurrentGameState);
        }

        private void SelectCursorMode(GameStateType gameStateType)
        {
            if (gameStateType == GameStateType.Playing)
            {
                HideCursor();
            }
            else
            {
                ShowCursor();
            }
        }
        
        public void HideCursor()
        {
            IsShowed = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ShowCursor()
        {
            IsShowed = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        public void Dispose()
        {
            _gameStateProvider.OnStateEntered -= SelectCursorMode;
            ShowCursor();
        }
    }
}