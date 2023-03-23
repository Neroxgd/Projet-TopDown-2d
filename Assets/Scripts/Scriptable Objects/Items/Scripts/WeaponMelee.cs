using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Melee", menuName = "Inventory System/Items/Weapon_Melee")]
public class WeaponMelee : ItemObject
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
        type = ItemType.Sword1;
        isTypeEquiped = false;
    }
}
