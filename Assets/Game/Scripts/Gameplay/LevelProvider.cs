using Game.Scripts.Gameplay.Abstractions;
using Game.Scripts.Gameplay.Data;

namespace Game.Scripts.Gameplay
{
    public class LevelProvider : ILevelProvider
    {
        public LevelStruct LevelStruct { get; set; }

        public LevelProvider(LevelStruct defaultLevel)
        {
            LevelStruct = defaultLevel;
        }
    }
}