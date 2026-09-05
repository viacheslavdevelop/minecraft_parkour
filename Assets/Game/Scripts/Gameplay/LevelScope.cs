using Game.Scripts.Gameplay.Components;
using Game.Scripts.Gameplay.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Gameplay
{
    public class LevelScope : LifetimeScope
    {
        [SerializeField] private Level _level;
        [SerializeField] private LevelData _levelData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelData);
            builder.RegisterBuildCallback(resolver => resolver.Inject(_level));
        }
    }
}