namespace Game.Scripts.Player.Abstractions
{
    public interface IGravityApplier
    {
        void DoGravity(float deltaTime, float gravity);
    }
}