using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _transformAnchor;

    private void Update(){
        Vector3 anchorPos = new Vector3(_transformAnchor.position.x, _transformAnchor.position.y, transform.position.z);
        transform.position = anchorPos;
    }
}
