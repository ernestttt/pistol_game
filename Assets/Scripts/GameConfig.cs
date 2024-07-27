using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "Game Config", order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifetime;
    [SerializeField] private float _radius;

    public float Speed => speed;
    public Bullet BulletPrefab => _bulletPrefab;
    public float BulletSpeed => _bulletSpeed;
    public float BulletLifetime => _bulletLifetime;
    public float Radius => _radius;
}
