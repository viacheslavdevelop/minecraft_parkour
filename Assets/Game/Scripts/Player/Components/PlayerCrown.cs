using Game.Scripts.Player.Data;
using UnityEngine;

namespace Game.Scripts.Player.Components
{
    public class PlayerCrown : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        
        private void OnDrawGizmos()
        {
            if (_playerConfig != null)
            {
                Gizmos.DrawSphere(transform.position, _playerConfig.CheckCrownRadius);
            }
        }
    }
}