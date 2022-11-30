using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleLife : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddLife();
    }
}
