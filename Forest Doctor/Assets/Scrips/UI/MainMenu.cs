using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTotalRan;
    [SerializeField] private TextMeshProUGUI _textBestScore;
    [SerializeField] private TextMeshProUGUI _textBacketsCount;

    [SerializeField] private TextMeshProUGUI _textStatus;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        UpdateText();
        StatusUpdate();
    }

    public void UpdateText()
    {
        _textBacketsCount.text = PlayerPrefs.GetInt("BacketsCount").ToString();
        _textBestScore.text = "Best score:" + PlayerPrefs.GetInt("BestScore").ToString() + "m";
        _textTotalRan.text = "Total ran:" + PlayerPrefs.GetInt("TotalRun").ToString() + "m";
        _slider.value = PlayerPrefs.GetInt("BestScore");
    }
    private void StatusUpdate()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore < 500)
        {
            _textStatus.text = "Beginner";
        }
        else if(bestScore>=500 && bestScore < 1000)
        {
            _textStatus.text = "No Bad";
        }
        else if(bestScore>=1000 && bestScore < 1500)
        {
            _textStatus.text = "Experienced";
        }
        else if(bestScore>=1500 && bestScore <= 2000)
        {
            _textStatus.text = "Sprinter";
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
