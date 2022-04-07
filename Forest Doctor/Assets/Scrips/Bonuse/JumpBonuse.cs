using UnityEngine;

public class JumpBonuse : MonoBehaviour,IBonuse
{
    public void GetBonuse(PlayerController playerController)
    {
        playerController.ChangeJumpForce(PlayerPrefs.GetInt("ProcentOfJump")*2);
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
