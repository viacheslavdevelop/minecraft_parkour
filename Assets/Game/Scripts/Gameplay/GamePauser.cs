using Game.Scripts.Gameplay.Abstractions;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class GamePauser : IPausable
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}