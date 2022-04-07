using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusesParents : MonoBehaviour
{
   
    private List<IBonuse> _bonusList;
    
    private void OnEnable()
    {
        if (_bonusList == null)
        {
            _bonusList = new List<IBonuse>();
            var bonuse = GetComponentsInChildren(typeof(Component), true).ToList();
            foreach (Component bonus in bonuse.ToList())
            {
                if (bonus is IBonuse)
                {
                    _bonusList.Add((IBonuse)bonus);

                }

            }
        }
        Debug.Log(PlayerPrefs.GetInt("ProcentOfSpeed").ToString());
        Activation();
    }

    private void Activation()
    {
        if (PlayerPrefs.GetInt("ProcentOfSpeed") >= 1)
        {
            foreach (IBonuse bonuse in _bonusList)
            {
                if (bonuse.GetGameObject().TryGetComponent(out ClockBonuse clockBonuse))
                {
                    clockBonuse.gameObject.SetActive(true);
                }
            }
        }

        if (PlayerPrefs.GetInt("ProcentOfJump") >= 1)
        {
            foreach (IBonuse bonuse in _bonusList)
            {
                if (bonuse.GetGameObject().TryGetComponent(out JumpBonuse jumpBonuse))
                {
                    jumpBonuse.gameObject.SetActive(true);
                }
            }
        }
    }
}
