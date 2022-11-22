using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableAmmo : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddAmmo();
    }
}