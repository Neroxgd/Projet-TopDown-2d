using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health_Potion Object", menuName = "Inventory System/Consumable/Health_Potion")]
public class HealthPotionObject : ItemObject
{
    public float health; 

    public override string TextInv()
    {
        return $"health : +{health}\n(Y) to consume item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.HealthPotion;
    }
}
