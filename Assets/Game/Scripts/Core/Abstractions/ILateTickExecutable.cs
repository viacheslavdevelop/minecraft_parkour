using VContainer.Unity;

namespace Game.Scripts.Core.Abstractions
{
    public interface ILateTickExecutable : ILateTickable
    {
        bool IsExecuting { get; set; }
    }
}