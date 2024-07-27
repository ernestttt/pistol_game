using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Config", menuName = "Game Config", order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private float speed = 1f;

    public float Speed => speed;
}
