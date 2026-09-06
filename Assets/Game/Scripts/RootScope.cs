using Game.Scripts.Core.Data;
using Game.Scripts.Gameplay;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts
{
    public class RootScope : LifetimeScope
    {
        [SerializeField] private Level _defaultLevelPrefab;
        [SerializeField] private GameConfig _gameConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameConfig);
            builder.RegisterInstance(_defaultLevelPrefab);
            builder.Register<LevelProvider>(Lifetime.Singleton).As<ILevelProvider>();
        }
    }
}