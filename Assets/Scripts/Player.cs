using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _inputManager.OnMove += Rotate;
    }

    private void Rotate(Vector2 moveVector){
        float angle = Vector3.SignedAngle(Vector3.up, moveVector, Vector3.forward);

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move(Vector2 moveVector)
    {
        Vector3 newPos = transform.position + (Vector3)moveVector * _gameConfig.Speed;

        if(_movementArea.Contains(newPos + minOffsetPlayer) && _movementArea.Contains(newPos + maxOffsetPlayer)){
            transform.position = newPos;
        }
    }

    public void Shoot(){
        float angle = Vector3.SignedAngle(Vector3.up, transform.up, Vector3.forward);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Bullet bullet = Instantiate(
            _gameConfig.BulletPrefab, transform.position, rotation).
            GetComponent<Bullet>();
    }
}
