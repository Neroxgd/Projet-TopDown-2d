using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableObject : ItemObject
{
    public override string TextInv()
    {
        throw new System.NotImplementedException();
    }

    void Awake()
    {
        type = ItemType.HealtPotion;
    }
}
