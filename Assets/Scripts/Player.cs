using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private SpriteRenderer _floor;

    private Bounds _movementArea;
    private SpriteRenderer _playerRenderer;

    private Vector3 minOffsetPlayer, maxOffsetPlayer;

    private void Awake(){
        _playerRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        minOffsetPlayer = _playerRenderer.bounds.min;
        maxOffsetPlayer = _playerRenderer.bounds.max;
        _movementArea = _floor.bounds;
        _inputManager.OnMove += Move;
    }

    private void Move(Vector2 moveVector)
    {
        Vector3 newPos = transform.position + (Vector3)moveVector * _gameConfig.Speed;

        if(_movementArea.Contains(newPos + minOffsetPlayer) && _movementArea.Contains(newPos + maxOffsetPlayer)){
            transform.position = newPos;
        }
    }
}
