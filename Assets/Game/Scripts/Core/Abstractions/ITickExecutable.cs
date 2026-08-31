using VContainer.Unity;

namespace Game.Scripts.Core.Abstractions
{
    public interface ITickExecutable : ITickable
    {
        bool IsExecuting { get; set; }
    }
}