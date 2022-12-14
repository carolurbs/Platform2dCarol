using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject currentMenuUI;
    public GameObject newMenuUI;
    private void Awake()
    {
        newMenuUI.SetActive(false);
        currentMenuUI.SetActive(true);
    }
    public void ShowMenu()
    {
        currentMenuUI.SetActive(false);
        newMenuUI.SetActive(true);
    }
}
