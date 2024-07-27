using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UIManager _uiManager;

    private void Start()
    {
        _uiManager.OnShoot += _player.Shoot;
        _uiManager.OnGunChange += _player.ChangeGun;
    }
}