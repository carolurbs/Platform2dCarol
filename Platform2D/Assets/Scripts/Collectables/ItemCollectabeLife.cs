using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectabeLife : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddLife();
    }
}
