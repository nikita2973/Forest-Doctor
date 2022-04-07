using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _backetCountText;
    [SerializeField] private TextMeshProUGUI _meterCountText;
    [SerializeField] private GameOverPanel _gameOverPanel;

    public int basketCount { get; private set; }
    public int meters { get; private set; }

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    
    private void FixedUpdate()
    {
        meters =(int) (transform.position.z / 3)+22;
        _meterCountText.text = meters + " m";
    }

    #region Work with other object

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Basket basket))
        {
            basket.gameObject.SetActive(false);
            basketCount++;
            _backetCountText.text = basketCount.ToString();
            StartCoroutine(ReturnObject(basket.gameObject,0.2f));
        }
       else if(other.gameObject.TryGetComponent(out IBonuse bonuse))
        {
            bonuse.GetBonuse(_playerController);
            bonuse.GetGameObject().SetActive(false);
            StartCoroutine(ReturnObject(bonuse.GetGameObject(), 120f));
        }
    }
    
    private IEnumerator ReturnObject(GameObject objectForReturn,float timeForReturn=0.2f)
    {
        yield return new WaitForSeconds(timeForReturn);
        objectForReturn.gameObject.SetActive(true);
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out Barries barrie))
        {
            if (_gameOverPanel == null)
            {
                _gameOverPanel = (GameOverPanel)FindObjectOfType(typeof(GameOverPanel), true);
            }
            _gameOverPanel.OpenPanel(barrie);
        }
    }

    #endregion
 

}
