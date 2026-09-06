using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Components;

namespace Game.Scripts.Gameplay
{
    public class LevelProvider : ILevelProvider
    {
        public Level Level { get; set; }

        public LevelProvider(Level defaultLevel)
        {
            Level = defaultLevel;
        }
    }
}