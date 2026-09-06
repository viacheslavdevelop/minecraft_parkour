using Game.Scripts.MainMenu.Components;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.MainMenu
{
    public class MainMenuScope : LifetimeScope
    {
        [SerializeField] private LevelSelectButton _levelSelectButton;
        [SerializeField] private ButtonsContainer _buttonsContainer;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_levelSelectButton);
            builder.RegisterInstance(_buttonsContainer);

            builder.RegisterEntryPoint<LevelButtonsSpawner>();
        }
    }
}