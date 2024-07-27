using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Joystick _joystick;

    private void Start(){
        _inputManager.OnMove += (moveVector) => _joystick.Move(moveVector);
        _inputManager.OnEndMove += _joystick.Reset;
    }
}
