using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.UI
{
    public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float _mobileSensitivityRatio = 0.1f;
        
        public Vector2 TouchInput { get; private set; }
        
        private Vector2 _pointerOld;
        private int _pointerId;
        private bool _isPressed;

        void Update()
        {
            if (_isPressed)
            {
                if (_pointerId >= 0 && _pointerId < Input.touches.Length)
                {
                    TouchInput = (Input.touches[_pointerId].position - _pointerOld) * _mobileSensitivityRatio;
                    _pointerOld = Input.touches[_pointerId].position;
                }
                else
                {
                    TouchInput = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - _pointerOld) * _mobileSensitivityRatio;
                    _pointerOld = Input.mousePosition;
                }
            }
            else
            {
                TouchInput = new Vector2();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            _pointerId = eventData.pointerId;
            _pointerOld = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }
    }
}