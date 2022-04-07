using UnityEngine;

public class Basket : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }
}
