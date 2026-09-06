using Game.Scripts.Gameplay;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;
using Game.Scripts.Gameplay.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.MainMenu
{
    public class MainMenuScope : LifetimeScope
    {
        [SerializeField] private LevelData _defaultLevelData;
        [SerializeField] private Level _defaultLevelPrefab;
        
        private static MainMenuScope _instance;

        protected override void Configure(IContainerBuilder builder)
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            LevelStruct defaultLevelStruct = new LevelStruct();
            defaultLevelStruct.LevelData = _defaultLevelData;
            defaultLevelStruct.LevelPrefab = _defaultLevelPrefab;

            builder.RegisterInstance(defaultLevelStruct);
            builder.Register<LevelProvider>(Lifetime.Singleton).As<ILevelProvider>();
            
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        protected override void OnDestroy()
        {
            if (_instance == this)
                _instance = null;

            base.OnDestroy();
        }
    }
}