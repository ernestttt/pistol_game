using UnityEngine;

public class PlayerMover : MonoBehaviour{
    [SerializeField] private GameConfig _gameConfig;

    private Bounds _movementBounds;
    private SpriteRenderer _playerRenderer;

    private Vector3 minOffsetPlayer, maxOffsetPlayer;

    private void Awake()
    {
        _playerRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBounds(Bounds bounds){
        _movementBounds = bounds;
        minOffsetPlayer = _playerRenderer.bounds.min;
        maxOffsetPlayer = _playerRenderer.bounds.max;
    }

    public void Move(Vector2 moveVector)
    {
        Vector3 newPos = transform.position + (Vector3)moveVector * _gameConfig.Speed;

        if (_movementBounds.Contains(newPos + minOffsetPlayer) && _movementBounds.Contains(newPos + maxOffsetPlayer))
        {
            transform.position = newPos;
        }
    }

    public void Rotate(Transform to)
    {
        float angle = Vector3.SignedAngle(Vector3.up, to.position - transform.position, Vector3.forward);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}