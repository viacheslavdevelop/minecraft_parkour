using UnityEngine;

namespace Game.Scripts.Gameplay.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private string _levelID;

        public string LevelID => _levelID;
    }
}