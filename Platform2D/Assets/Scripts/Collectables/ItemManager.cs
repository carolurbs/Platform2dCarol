using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;


public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI amountUI;

    new private void Awake()
    {
        base.Awake();
        Reset();

    }
    private void Reset()
    {
        coins.value = 0;
    }
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    private void Update()
    {
        amountUI.text= coins.value.ToString();
    }
}
