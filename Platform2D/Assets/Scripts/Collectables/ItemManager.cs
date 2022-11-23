using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;


public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt ammo;
    new private void Awake()
    {
        base.Awake();
        Reset();

    }
    private void Reset()
    {
        coins.value = 0;
        ammo.value = 5; 
    }
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

   

    public void AddAmmo(int fire =1)
    {
        ammo.value += fire;
    }

   
}

