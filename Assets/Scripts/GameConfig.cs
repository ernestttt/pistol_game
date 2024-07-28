using UnityEngine;

namespace PistolGame
{
    [CreateAssetMenu(fileName = "Game Config", menuName = "Game Config", order = 1)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _bulletLifetime;
        [SerializeField] private float _radius;
        [SerializeField] private float _bulletDamage = 1f;

        public float Speed => speed;
        public Bullet BulletPrefab => _bulletPrefab;
        public float BulletSpeed => _bulletSpeed;
        public float BulletLifetime => _bulletLifetime;
        public float Radius => _radius;
        public float BulletDamage => _bulletDamage;
    }
}

