using UnityEngine;

namespace PistolGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private PlayerShooter _shooter;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private SpriteRenderer _floorRenderer;

        private void Start()
        {
            _inputManager.OnMove += _mover.Move;
            _mover.SetBounds(_floorRenderer.bounds);
        }

        public void Shoot()
        {
            _shooter.Shoot();
        }

        public void ChangeGun(int gunIndex)
        {
            _shooter.ChangeGun(gunIndex);
        }
    }
}

