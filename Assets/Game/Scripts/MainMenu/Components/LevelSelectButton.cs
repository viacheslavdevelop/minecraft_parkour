using Game.Scripts.Core.Data;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.MainMenu.Components
{
    public class LevelSelectButton : MonoBehaviour
    {
        public Level Level { get; set; }
        
        [SerializeField] private Button _playButton;

        private ILevelProvider _levelProvider;
        private string _gameplaySceneName;
        
        [Inject]
        public void Construct(ILevelProvider levelProvider, GameConfig gameConfig, Level levelPrefab)
        {
            _levelProvider = levelProvider;
            _gameplaySceneName = gameConfig.GameplaySceneName;
            Level = levelPrefab;

            _playButton.onClick.AddListener(Play);
        }

        private void Play()
        {
            _levelProvider.Level = Level;
            
            SceneManager.LoadScene(_gameplaySceneName);
        }
    }
}