using Game.Scripts.Gameplay;
using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.MainMenu
{
    public class RootScope : LifetimeScope
    {
        [SerializeField] private Level _defaultLevelPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_defaultLevelPrefab);
            builder.Register<LevelProvider>(Lifetime.Singleton).As<ILevelProvider>();
        }
    }
}