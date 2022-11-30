using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthUI : MonoBehaviour
{
    public SO_HealthSetup health;
    public TextMeshProUGUI lifeUI;

    // Update is called once per frame
    void Update()
    {
        lifeUI.text = health._currentLife.ToString();
    }
}
