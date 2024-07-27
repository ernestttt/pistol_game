using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private SpriteRenderer _floor;

    private Bounds _movementArea;
    private SpriteRenderer _playerRenderer;

    private Dictionary<GunType, Action> _gunActions = new Dictionary<GunType, Action>();

    private Vector3 minOffsetPlayer, maxOffsetPlayer;

    private GunType _currentGunType = GunType.Pistol;
    private bool _isMakingShoot = false;

    private void Awake(){
        _playerRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start(){
        minOffsetPlayer = _playerRenderer.bounds.min;
        maxOffsetPlayer = _playerRenderer.bounds.max;
        _movementArea = _floor.bounds;
        _inputManager.OnMove += Move;
        _inputManager.OnMove += Rotate;

        // init guns

        _gunActions.Add(GunType.Pistol, async () => {
            _isMakingShoot = true;
            MakeOneShoot(); 
            await Task.Delay(200);
            _isMakingShoot = false;
            });

        _gunActions.Add(GunType.Shotgun, async () => {
            _isMakingShoot = true;
            for (int i = 0; i < 5; i++){
                MakeOneShoot();
                await Task.Delay(200);
            }
            _isMakingShoot = false;
        });
    }

    private void Rotate(Vector2 moveVector){
        if(_isMakingShoot) return;

        float angle = Vector3.SignedAngle(Vector3.up, moveVector, Vector3.forward);

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Move(Vector2 moveVector)
    {
        if (_isMakingShoot) return;
        Vector3 newPos = transform.position + (Vector3)moveVector * _gameConfig.Speed;

        if(_movementArea.Contains(newPos + minOffsetPlayer) && _movementArea.Contains(newPos + maxOffsetPlayer)){
            transform.position = newPos;
        }
    }

    public void ChangeGun(int gunIndex){
        GunType gunType = (GunType)gunIndex;

        _currentGunType = gunType;
    }

    public void Shoot(){
        if(_isMakingShoot) return;
        _gunActions[_currentGunType]?.Invoke();
    }

    private void MakeOneShoot(){
        if(!this)   return;
        float angle = Vector3.SignedAngle(Vector3.up, transform.up, Vector3.forward);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Bullet bullet = Instantiate(
            _gameConfig.BulletPrefab, transform.position, rotation).
            GetComponent<Bullet>();
    }
}
