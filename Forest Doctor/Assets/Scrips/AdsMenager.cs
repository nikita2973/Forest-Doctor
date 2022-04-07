using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Monetization;
using ShowResult = UnityEngine.Monetization.ShowResult;

public class AdsMenager : MonoBehaviour   {

    [SerializeField] private Button _adButton;
    [SerializeField] private GameOverPanel _gameOverPanel;

    [SerializeField] private MainMenu _mainMenu;
private string placementId = "Rewarded_Android";
#if UNITY_IOS
   private string gameId = "4601179";
#elif UNITY_ANDROID
    private string gameId = "4601178";
#endif

void Start()
{

    if (_adButton)
    {
        _adButton.onClick.AddListener(ShowAd);
    }

    if (Monetization.isSupported)
    {
        Monetization.Initialize(gameId,false);
    }
}

void Update()
{
    if (_adButton)
    {
        _adButton.interactable = Monetization.IsReady(placementId);
    }
}

void ShowAd()
{
    ShowAdCallbacks options = new ShowAdCallbacks();
    options.finishCallback = HandleShowResult;
    ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
    ad.Show(options);
}

void HandleShowResult(ShowResult result)
{
    if (result == ShowResult.Finished)
    {
            if (_gameOverPanel != null)
            {
                _gameOverPanel.Continue();
            }
            else if(_mainMenu!=null)
            {
                PlayerPrefs.SetInt("BacketsCount", PlayerPrefs.GetInt("BacketsCount") + 100);
                _mainMenu.UpdateText();
            }
    }
    else if (result == ShowResult.Skipped)
    {
        Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
    }
    else if (result == ShowResult.Failed)
    {
        Debug.LogError("Video failed to show");
    }
}
}
