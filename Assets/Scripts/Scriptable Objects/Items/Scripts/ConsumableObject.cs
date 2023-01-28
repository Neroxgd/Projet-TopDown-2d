using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableObject : ItemObject
{
    void Awake()
    {
        type = ItemType.HealtPotion;
    }
}
