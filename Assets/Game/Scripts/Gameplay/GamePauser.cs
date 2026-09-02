using Game.Scripts.Core.Abstractions;
using Game.Scripts.Core.GameState;
using Game.Scripts.Gameplay.Abstractions;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class GamePauser : IPausable
    {
        public bool IsPause => Mathf.Approximately(Time.timeScale, 1) ? false : true;

        private IGameStateProvider _gameStateProvider;

        public GamePauser(IGameStateProvider gameStateProvider)
        {
            _gameStateProvider = gameStateProvider;
        }


        public void Pause()
        {
            Time.timeScale = 0;
            _gameStateProvider.SetupState(GameStateType.Paused);
            Debug.Log("Pause");
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            _gameStateProvider.SetupState(GameStateType.Playing);
            Debug.Log("Unpause");
        }
    }
}