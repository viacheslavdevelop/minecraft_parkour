using UnityEngine;

namespace Game.Scripts.DebugTools
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
