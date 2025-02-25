using System;
using UnityEngine;
using UnityEngine.UI;

namespace PistolGame.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Toggle[] _gunGroup;

        public event Action OnShoot;
        public event Action<int> OnGunChange;

        private void Start()
        {
            _inputManager.OnMove += (moveVector) => _joystick.Move(moveVector);
            _inputManager.OnEndMove += _joystick.Reset;
            _shootButton.onClick.AddListener(() => OnShoot?.Invoke());

            for (int i = 0; i < _gunGroup.Length; i++)
            {
                int gunIndex = i;
                _gunGroup[i].onValueChanged.AddListener((isOn) =>
                {
                    if (!isOn) return;
                    OnGunChange?.Invoke(gunIndex);
                });
            }
        }
    }
}

