using Game.Scripts.Core.Abstractions;
using Game.Scripts.Player.Abstractions;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class MobileCursorController : ICursorController
    {
        public bool IsShowed { get; private set; }

        private IGameStateProvider _gameStateProvider;

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
    }
}