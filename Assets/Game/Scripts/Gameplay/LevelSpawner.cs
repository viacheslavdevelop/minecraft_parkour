using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Gameplay
{
    public class LevelSpawner : ILevelSpawner, IStartable
    {
        private readonly IObjectResolver _resolver;

        public LevelSpawner(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public void Start()
        {
            SpawnLevel(_resolver.Resolve<ILevelProvider>().Level);
        }
        
        public Level SpawnLevel(Level level)
        {
            Level spawnedLevel = _resolver.Instantiate(level);
            
            return spawnedLevel;
        }
    }
}