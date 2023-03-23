using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Distance", menuName = "Inventory System/Items/Weapon_Distance")]
public class WeaponDistance : ItemObject
{
    public int atkPower;
    public static bool isTypeEquiped;
    public float weaponSpeed;
    public bool ammo; 
    public float manaConsumed;

    public override string TextInv()
    {
        return $"attack : +{atkPower}\n(Y) to equipe item\n(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Bow1;
        isTypeEquiped = false;
    }
}
