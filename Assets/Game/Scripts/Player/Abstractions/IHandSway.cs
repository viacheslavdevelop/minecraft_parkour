using UnityEngine;

namespace Game.Scripts.Player.Abstractions
{
    public interface IHandSway
    {
        void Sway(Vector2 direction, float deltaTime);
    }
}