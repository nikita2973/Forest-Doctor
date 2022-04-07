using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;

public class UpdateBonuse : MonoBehaviour
{
    [SerializeField] private Image _backgroundClockImage;
    [SerializeField] private Image _backgroundJumpImage;
    //Button text
    [SerializeField] private TextMeshProUGUI _updateButtonClockText;
    [SerializeField] private TextMeshProUGUI _updateButtonJumpText;
    //Price
    [SerializeField] private TextMeshProUGUI _updatePriceClockText;
    [SerializeField] private TextMeshProUGUI _updatePriceJumpText;

    private const string JUMP_PROCENT = "ProcentOfJump";
    private const string CLOCK_PROCENT = "ProcentOfSpeed";

    private const int MAX_PROCES = 5;

    private int _priceClock = 1200;
    private int _priceJump = 1000;

    private int _jumpProces;
    private int _clockProces;

    private void Awake()
    {
        _jumpProces = PlayerPrefs.GetInt(JUMP_PROCENT);
        _clockProces = PlayerPrefs.GetInt(CLOCK_PROCENT);
       
        UpdateText();
    }

    private void UpdateText()
    {

        UpdatejumpText();
        UpdateClockText();
    }

    private void UpdateClockText()
    {
        int priceClock = _priceClock + (_clockProces * 1000);
        if (_clockProces > 0)
        {
            _updateButtonClockText.text = "Update";
            _backgroundClockImage.fillAmount = _clockProces * 0.20f;
        }
        else
        {
            _updateButtonClockText.text = "Buy";

        }

        _updatePriceClockText.text = priceClock.ToString();
    }

    private void UpdatejumpText()
    {
        int priceJump = _priceJump + (_jumpProces * 1000);
        
        if (_jumpProces > 0)
        {
            _updateButtonJumpText.text = "Update";
            _backgroundJumpImage.fillAmount = _jumpProces * 0.20f;
        }
        else
        {
            _updateButtonJumpText.text = "Buy";
        }

        _updatePriceJumpText.text = priceJump.ToString();
    }

    public void UpdateClock()
    {
        if (PlayerPrefs.GetInt("BacketsCount") >= _priceClock + (_clockProces * 1000) &&_clockProces< MAX_PROCES)
        {
            PlayerPrefs.SetInt("BacketsCount", (PlayerPrefs.GetInt("BacketsCount") - (_priceClock + (_clockProces * 1000))));
            _clockProces = _clockProces + 1;

            UpdateClockText();

            PlayerPrefs.SetInt(CLOCK_PROCENT, _clockProces);
            PlayerPrefs.Save();
        }
    }

    public void UpdateJump()
    {
        if (PlayerPrefs.GetInt("BacketsCount") >= _priceJump + (_jumpProces * 1000)&& _jumpProces<MAX_PROCES)
        {
            PlayerPrefs.SetInt("BacketsCount", (PlayerPrefs.GetInt("BacketsCount") - (_priceJump + (_jumpProces * 1000))));

           _jumpProces = _jumpProces + 1;

            UpdatejumpText();

            PlayerPrefs.SetInt(JUMP_PROCENT, _jumpProces);

            PlayerPrefs.Save();
        }
    }
}
