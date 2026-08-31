using UnityEngine;

namespace Game.Scripts.Debug
{
    public class FPSLimiter : MonoBehaviour
    {
        [SerializeField] private int _targetFPS;
    
        void Start()
        {
            Application.targetFrameRate = _targetFPS;
        }
    }
}
