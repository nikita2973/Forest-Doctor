using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuPanel : MonoBehaviour
{
    [SerializeField]private GameObject _pauseButton;
    [SerializeField] private PlayerStatus _playerStatus;
    public void onPauseButton(bool open)
    {
        _pauseButton.GetComponent<Button>().interactable = !open;
        if (open)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        gameObject.SetActive(open);
    }
    public  void Restart()
    {
        int scoreM = _playerStatus.meters;
        int countBacket = _playerStatus.basketCount;
        UpdateParameters(scoreM, countBacket);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        int scoreM = _playerStatus.meters;
        int countBacket = _playerStatus.basketCount;
        UpdateParameters(scoreM, countBacket);
        SceneManager.LoadScene(0);
    }

    private  void UpdateParameters(int scoreM, int countBacket)
    {
        PlayerPrefs.SetInt("BacketsCount", PlayerPrefs.GetInt("BacketsCount") + countBacket);
        if (PlayerPrefs.GetInt("BestScore") < scoreM)
        {
            PlayerPrefs.SetInt("BestScore", scoreM);
        }
        PlayerPrefs.SetInt("TotalRun", PlayerPrefs.GetInt("TotalRun") + scoreM);
        PlayerPrefs.Save();
    }

}

