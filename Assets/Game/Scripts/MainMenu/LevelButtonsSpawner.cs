using System.Collections.Generic;
using Game.Scripts.Core.Data;
using Game.Scripts.Gameplay.Components;
using Game.Scripts.MainMenu.Abstractions;
using Game.Scripts.MainMenu.Components;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.MainMenu
{
    public class LevelButtonsSpawner : ILevelButtonsSpawner, IStartable
    {
        private readonly List<Level> _levels;
        private readonly LevelSelectButton _buttonPrefab;
        private readonly ButtonsContainer _buttonsContainer;
        private readonly IObjectResolver _objectResolver;

        public LevelButtonsSpawner(GameConfig gameConfig, LevelSelectButton levelSelectButton, IObjectResolver resolver, ButtonsContainer buttonsContainer)
        {
            _levels = gameConfig.Levels;
            _buttonPrefab = levelSelectButton;
            _objectResolver = resolver;
            _buttonsContainer = buttonsContainer;
        }
        
        public void Start()
        {
            SpawnButtons();
        }
        
        public void SpawnButtons()
        {
            foreach (var level in _levels)
            {
                LevelSelectButton spawnedButton = _objectResolver.Instantiate(_buttonPrefab, _buttonsContainer.gameObject.transform);
                spawnedButton.Level = level;
            }
        }
    }
}