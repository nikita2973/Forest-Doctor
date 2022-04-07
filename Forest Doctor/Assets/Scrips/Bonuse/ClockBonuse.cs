using UnityEngine;

public class ClockBonuse : MonoBehaviour,IBonuse
{
    public void GetBonuse(PlayerController playerController)
    {
        playerController.ChangeSpeed(PlayerPrefs.GetInt("ProcentOfSpeed")*6);
    }

    public GameObject GetGameObject()
    {
     return gameObject;
    }

    private void Update()
    {
        transform.Rotate(0, 0, 40 * Time.deltaTime);
    }
}
