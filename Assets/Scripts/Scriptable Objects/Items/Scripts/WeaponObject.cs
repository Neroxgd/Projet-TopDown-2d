using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemObject
{
    public int atkPower;
    public bool isTypeEquiped;

    public override string TextInv()
    {
        return "(Y) to equipe item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Sword;
    }
}
