using UnityEngine;

[CreateAssetMenu(fileName = "New Armor_Chestplate Object", menuName = "Inventory System/Items/Armor_Chestplate")]
public class Armor_ChestplateObject : ItemObject, IEquipable
{
    public int defPower;
    public static bool isTypeEquiped;

    public override string TextInv()
    {
        return $"defense : +{defPower}\n(Y) pour equiper l'objet\n(T) pour lacher l'objet";
    }

    void Awake()
    {
        isTypeEquiped = false;
    }
    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign, SlotsManager slotsManager, InventorySlot inventorySlot) { isTypeEquiped = sign; }
    void IEquipable.SetStatsPlayer()
    {
        PlayerStatistic.Instance.Armor_Chestplate = defPower;
    }
    void IEquipable.ResetStatsPlayer()
    {
        PlayerStatistic.Instance.Armor_Chestplate = 0;
    }
}
