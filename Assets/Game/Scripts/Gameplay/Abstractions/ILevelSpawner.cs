using Game.Scripts.Gameplay.Components;

namespace Game.Scripts.Gameplay.Abstractions
{
    public interface ILevelSpawner
    {
        Level SpawnLevel(Level level);
    }
}