using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _shootButton;

    public event Action OnShoot;

    private void Start(){
        _inputManager.OnMove += (moveVector) => _joystick.Move(moveVector);
        _inputManager.OnEndMove += _joystick.Reset;
        _shootButton.onClick.AddListener(() => OnShoot?.Invoke());
    }
}
