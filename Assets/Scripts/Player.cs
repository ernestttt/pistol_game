using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerShooter _shooter;

    public void Shoot(){
        _shooter.Shoot();
    }

    public void ChangeGun(int gunIndex){
        _shooter.ChangeGun(gunIndex);
    }
}
