using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;

    private float lifeTime = 0;

    private void Update(){
        transform.position += _gameConfig.BulletSpeed * transform.up * Time.deltaTime;

        lifeTime += Time.deltaTime;
        if(lifeTime > _gameConfig.BulletLifetime)
        {
            Destroy(gameObject);
        }
    }
}
