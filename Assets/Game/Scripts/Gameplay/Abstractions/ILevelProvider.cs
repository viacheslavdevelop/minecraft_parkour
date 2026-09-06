using Game.Scripts.Gameplay.Components;
using Game.Scripts.Gameplay.Data;

namespace Game.Scripts.Gameplay.Abstractions
{
    public interface ILevelProvider
    {
        public LevelStruct LevelStruct { get; set; }
    }
}