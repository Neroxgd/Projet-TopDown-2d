using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light Object", menuName = "Inventory System/Items/Light")]
public class LightObject : ItemObject
{
    public int radiusLight;
    public bool isEquiped;
    public static bool isTypeEquiped;

    public override string TextInv()
    {
        return "(Y) to equipe item\n(T) to drop item";
    }
    void Awake()
    {
        type = ItemType.Torch;
        isTypeEquiped = false;
    }
}
