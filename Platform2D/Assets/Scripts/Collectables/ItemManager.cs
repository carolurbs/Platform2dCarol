using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;


public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt ammo;
    public SO_HealthSetup health;
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

    public void AddLife(int life = 1)
    {
        health._currentLife += life;
    }
}

