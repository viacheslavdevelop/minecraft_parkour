using Game.Scripts.GameInput.Abstractions;
using UnityEngine;

namespace Game.Scripts.Gameplay.Input
{
    public class DesktopPauseInput : IPauseInput
    {
        public bool PauseButtonPressed => UnityEngine.Input.GetKeyDown(KeyCode.Escape);
    }
}