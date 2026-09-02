namespace Game.Scripts.Gameplay.Abstractions
{
    public interface IPausable
    {
        public bool IsPause { get; }
        
        void Pause();
        void Unpause();
    }
}