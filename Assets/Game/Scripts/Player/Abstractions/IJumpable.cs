namespace Game.Scripts.Player.Abstractions
{
    public interface IJumpable
    {
        void Jump(bool isJump, float deltaTime);
    }
}