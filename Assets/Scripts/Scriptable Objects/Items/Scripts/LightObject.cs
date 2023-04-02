using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "New Light Object", menuName = "Inventory System/Items/Light")]
public class LightObject : ItemObject, IEquipable
{
    public int radiusLight;
    public bool isEquiped;
    public static bool isTypeEquiped;

    public override string TextInv()
    {
        return "(Y) to equipe item\n(T) to drop item";
    }
    void Awake()
    {
        type = ItemType.Torch;
        isTypeEquiped = false;
    }

    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign, SlotsManager slotsManager)
    {
        isTypeEquiped = sign;
        slotsManager.light2DPlayer.SetActive(isTypeEquiped ? true : false);
    }
    void IEquipable.SetStatsPlayer() { }
    void IEquipable.ResetStatsPlayer() { }
}
