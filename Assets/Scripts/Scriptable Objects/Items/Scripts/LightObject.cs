using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light Object", menuName = "Inventory System/Items/Light")]
public class LightObject : ItemObject
{
    public int radiusLight;
    public bool isEquiped;
    void Awake()
    {
        type = ItemType.Torch;
    }
}
