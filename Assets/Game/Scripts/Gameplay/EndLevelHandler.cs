using Game.Scripts.Core.Data;
using Game.Scripts.Core.Saves;
using Game.Scripts.Gameplay.Abstractions;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Game.Scripts.Gameplay
{
    public class EndLevelHandler : IEndLevelHandler
    {
        private readonly SmartSave _smartSave;
        private readonly string _mainMenuSceneName;

        public EndLevelHandler(SmartSave smartSave, GameConfig gameConfig)
        {
            _smartSave = smartSave;
            _mainMenuSceneName = gameConfig.MainMenuSceneName;
        }
        
        public void HandleEndLevel(string levelID)
        {
            if (YG2.saves.CompletedLevels == null)
            {
                YG2.saves.CompletedLevels = new();
            }
            
            YG2.saves.CompletedLevels.Add(levelID);
            
            Debug.Log(YG2.saves.CompletedLevels);
            
            _smartSave.SaveImmediately();

            SceneManager.LoadScene(_mainMenuSceneName);
        }
    }
}