namespace Game.Scripts.Player.Abstractions
{
    public interface ICursorController
    {
        public bool IsShowed { get; }
        
        void HideCursor();
        void ShowCursor();
    }
}
