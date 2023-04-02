using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor_Helmet Object", menuName = "Inventory System/Items/Armor_Helmet")]
public class Armor_HelmetObject : ItemObject, IEquipable
{
    public int defPower;
    public static bool isTypeEquiped;

    public override string TextInv()
    {
        return $"defense : +{defPower}\n(Y) to equipe item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Helmet;
        isTypeEquiped = false;
    }

    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign, SlotsManager slotsManager, InventorySlot inventorySlot) { isTypeEquiped = sign; }
    void IEquipable.SetStatsPlayer()
    {
        PlayerStatistic.Instance.AttackMelee = defPower;
    }
    void IEquipable.ResetStatsPlayer()
    {
        PlayerStatistic.Instance.AttackMelee = 0;
    }
}
