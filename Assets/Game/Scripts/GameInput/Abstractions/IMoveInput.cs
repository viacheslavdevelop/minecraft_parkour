using UnityEngine;

namespace Game.Scripts.GameInput.Abstractions
{
    public interface IMoveInput
    {
        Vector2 MoveAxis { get; }
    }
}