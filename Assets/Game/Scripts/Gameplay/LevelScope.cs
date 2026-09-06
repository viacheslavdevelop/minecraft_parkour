using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Gameplay
{
    public class LevelScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelSpawner>();
        }
    }
}