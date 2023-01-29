using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipable Object", menuName = "Inventory System/Items/Equipable")]
public class EquipableObject : ItemObject
{
    public int atkPower;
    public int defencePower;
    public bool isEquiped;
    void Awake()
    {
        type = ItemType.Sword;
    }
}
