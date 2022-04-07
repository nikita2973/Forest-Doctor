using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    private Barries _barries;
    private void OnEnable()
    {
        _pauseButton.interactable = false;
    }
    public void OpenPanel(Barries barries)
    {
        gameObject.SetActive(true);
        _barries = barries;
        Time.timeScale = 0;
    }
    public void Continue()
    {
        if (_barries != null)
        {
            Debug.Log("continue");
           Destroy( _barries.gameObject);
            Time.timeScale = 1;
            _pauseButton.interactable = true;
            gameObject.SetActive(false);
        }
    }

}
