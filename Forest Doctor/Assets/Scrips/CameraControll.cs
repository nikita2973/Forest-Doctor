using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    private float _zDistance;

    private void Start()
    {
       _zDistance = _player.gameObject.transform.position.z - transform.position.z;
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.gameObject.transform.position.z - _zDistance) ;
    }
}
