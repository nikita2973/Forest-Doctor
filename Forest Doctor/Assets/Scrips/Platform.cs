using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]private GameObject[] _massiveOfEnvSets;
    private GameObject activeSet;
    private void Start()
    {
        SelectSets();
    }
    public void SelectSets()
    {
        int setNumber = Random.Range(0, _massiveOfEnvSets.Length);
        if (activeSet != null)
        {
            activeSet.SetActive(false);
        }
        _massiveOfEnvSets[setNumber].SetActive(true);
        activeSet = _massiveOfEnvSets[setNumber];
    }
}
