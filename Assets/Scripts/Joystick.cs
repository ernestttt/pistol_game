using UnityEngine;

namespace PistolGame.UI
{
    public class Joystick : MonoBehaviour
    {
        [SerializeField] private RectTransform _joystickFrame;
        [SerializeField] private RectTransform _joystick;

        private float _joystickFrameRadius;

        private void Awake()
        {
            _joystickFrameRadius = _joystickFrame.sizeDelta.x * 0.5f;
        }

        public void Move(Vector2 move)
        {
            move = move * 50f;
            Vector2 clampedMove = Vector2.ClampMagnitude(move, _joystickFrameRadius);
            _joystick.anchoredPosition = clampedMove;
        }

        public void Reset()
        {
            _joystick.anchoredPosition = Vector2.zero;
        }
    }
}