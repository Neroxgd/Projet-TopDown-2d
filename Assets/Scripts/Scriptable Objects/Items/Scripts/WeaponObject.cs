using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemObject
{
    public int atkPower;
    public int defencePower;
    public bool equipable;
    public bool isEquiped;
    void Awake()
    {
        type = ItemType.Sword;
    }
}
