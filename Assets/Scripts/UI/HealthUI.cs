using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIcon;
    private List<GameObject> _healthIconsList = new List<GameObject>();


    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(HealthIcon, transform);
            _healthIconsList.Add(newIcon);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthIconsList.Count; i++)
        {
            if(i < health)
            {
                _healthIconsList[i].SetActive(true);
            }
            else
            {
                _healthIconsList[i].SetActive(false);
            }
        }
    }

}
