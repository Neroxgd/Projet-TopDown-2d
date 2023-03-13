using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor_Helmet Object", menuName = "Inventory System/Items/Armor_Helmet")]
public class Armor_HelmetObject : ItemObject
{
    public int defPower;
    public bool isTypeEquiped;

    public override string TextInv()
    {
        return $"defense : +{defPower}\n(Y) to equipe item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Helmet;
    }
}
