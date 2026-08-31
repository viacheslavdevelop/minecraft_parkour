using UnityEngine;

namespace Game.Scripts.Player.Abstractions
{
    public interface IRotatable
    {
        void Rotate(Vector2 direction, float sensitivity, float deltaTime);
    }
}