using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[CreateAssetMenu(fileName = "New Armor_Chestplate Object", menuName = "Inventory System/Items/Armor_Chestplate")]
public class Armor_ChestplateObject : ItemObject, IEquipable
{
    public int defPower;
    public static bool isTypeEquiped;

    public override string TextInv()
    {
        return $"defense : +{defPower}\n(Y) to equipe item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Chestplate;
        isTypeEquiped = false;
    }
    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign) { isTypeEquiped = sign; }
    void IEquipable.SetStatsPlayer()
    {
        FieldInfo variableInfo = GetType().GetField(defPower.ToString());
        if (variableInfo == null) return;
        PlayerStatistic.Instance.AttackMelee = defPower;
    }
    void IEquipable.ResetStatsPlayer()
    {
        FieldInfo variableInfo = GetType().GetField(defPower.ToString());
        if (variableInfo == null) return;
        PlayerStatistic.Instance.AttackMelee = 0;
    }
}
