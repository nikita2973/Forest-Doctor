using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private int _toNewTile;
    [SerializeField] private Transform _player;
    private int countUpdate = 1;
    private int tileLenght = 150;
    private Queue<Platform> _platformQueue = new Queue<Platform>();
    private void Start()
    {
        Time.timeScale = 1;
      foreach(Platform platform in _platforms)
        {
            _platformQueue.Enqueue(platform);
        }
        _toNewTile = tileLenght * countUpdate;
    }
   
    private void FixedUpdate()
    {
        if (_player.position.z+15 > _toNewTile )
        {
            _toNewTile = tileLenght * countUpdate;
            Platform plat=_platformQueue.Dequeue();
            countUpdate++;

            plat.transform.localPosition=new Vector3(plat.transform.localPosition.x, plat.transform.localPosition.y, plat.transform.localPosition.z+300/*tileLenght * countUpdate*/);
            _platformQueue.Enqueue(plat);
            plat.SelectSets();
            
            _toNewTile = tileLenght * countUpdate;
        }
    }

}
