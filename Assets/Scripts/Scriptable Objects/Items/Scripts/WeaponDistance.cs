using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[CreateAssetMenu(fileName = "New Weapon Distance", menuName = "Inventory System/Items/Weapon_Distance")]
public class WeaponDistance : ItemObject, IEquipable
{
    public int atkPower;
    public static bool isTypeEquiped;
    public float weaponSpeed;

    public override string TextInv()
    {
        return $"attack : +{atkPower}\n(Y) to equipe item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Bow1;
        isTypeEquiped = false;
    }

    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign, SlotsManager slotsManager, InventorySlot inventorySlot)
    {
        isTypeEquiped = sign;
        slotsManager.uIAmmo.SetActive(isTypeEquiped ? true : false);
    }
    void IEquipable.SetStatsPlayer()
    {
        PlayerStatistic.Instance.AttackDistance = atkPower;
    }
    void IEquipable.ResetStatsPlayer()
    {
        PlayerStatistic.Instance.AttackDistance = 0;
    }


}
