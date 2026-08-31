using UnityEngine;

namespace Game.Scripts.Player.Abstractions
{
    public interface IMovable
    {
        void Move(Vector2 direction, float deltaTime, float moveSpeed);
    }
}