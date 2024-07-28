using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 _startMousePos = Vector3.zero;
    private bool _buttonPressed = false;
    private bool _thresholdCrossed = false;

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;


    private void Update()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetMouseButtonDown(0))
        {
            _buttonPressed = true;
            _startMousePos = Input.mousePosition;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _buttonPressed = false;
            _thresholdCrossed = false;

            OnEndMove?.Invoke();
        }

        if (Input.GetMouseButton(0) && _buttonPressed)
        {
            if (!_thresholdCrossed)
            {
                _thresholdCrossed = (Input.mousePosition - _startMousePos).magnitude > 3;
                OnStartMove?.Invoke();
            }
            else
            {
                move = Input.mousePosition - _startMousePos;
                move *= Time.deltaTime;
                OnMove?.Invoke(new Vector3(move.x, move.y));
            }
        }

    }
}
