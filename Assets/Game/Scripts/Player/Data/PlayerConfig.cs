using UnityEngine;

namespace Game.Scripts.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [field:SerializeField] public float MaxSpeed { get; private set; }
    }
}
