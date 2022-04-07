using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class QualityControll : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] private TextMeshProUGUI _qualityLevel;
    private int _quality;
    private void Start()
    {
        _quality = PlayerPrefs.GetInt("qualitySetting");
        QualitySettings.SetQualityLevel(_quality, true);
        ChangeQualityText(_quality);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_quality < 5)
        {
            _quality++;
        }
        else
        {
            _quality = 0;
        }
        PlayerPrefs.SetInt("qualitySetting", _quality);
        QualitySettings.SetQualityLevel(_quality, true);
        ChangeQualityText(_quality);
        PlayerPrefs.Save();
    }
    private void ChangeQualityText(int quality)
    {
        switch (quality) {
            case 0:
                _qualityLevel.text = "Very Low";
                break;        
            case 1:
                _qualityLevel.text = "Low";
                break;         
            case 2:
                _qualityLevel.text = "Medium";
                break;           
            case 3:
                _qualityLevel.text = "High";
                break;        
            case 4:
                _qualityLevel.text = "Very High";
                break;        
            case 5:
                _qualityLevel.text = "Ultra";
                break;
        
        
        }

    }
}