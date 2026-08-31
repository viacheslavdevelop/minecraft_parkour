using UnityEngine;

namespace Game.Scripts.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [field:SerializeField] public float MaxSpeed { get; private set; }
        [field:SerializeField] public float Sensitivity { get; private set; }
        [field:SerializeField] public float MaxPitch { get; private set; }
        [field:SerializeField] public float MinPitch { get; private set; }
    }
}
