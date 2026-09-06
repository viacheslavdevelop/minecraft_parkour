using Game.Scripts.Gameplay.Components;

namespace Game.Scripts.Gameplay.Abstractions
{
    public interface ILevelProvider
    {
        public Level Level { get; set; }
    }
}