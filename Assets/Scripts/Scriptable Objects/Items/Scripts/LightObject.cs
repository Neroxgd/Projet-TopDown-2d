using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light Object", menuName = "Inventory System/Items/Light")]
public class LightObject : ItemObject, IEquipable
{
    public float intensity;
    public float distance;
    public Vector2 angleLight;
    public static bool isTypeEquiped;

    public override string TextInv()
    {
        return "(Y) to equipe item\n(T) to drop item";
    }
    void Awake()
    {
        type = ItemType.Torch1;
        isTypeEquiped = false;
    }

    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign, SlotsManager slotsManager, InventorySlot inventorySlot)
    {
        isTypeEquiped = sign;
        slotsManager.playerLight.gameObject.SetActive(isTypeEquiped ? true : false);
        LightObject instancelight = inventorySlot.item as LightObject;
        slotsManager.playerLight.SetLightPlayer(instancelight.intensity, instancelight.distance, instancelight.angleLight);
    }
    void IEquipable.SetStatsPlayer() { }
    void IEquipable.ResetStatsPlayer() { }
}
