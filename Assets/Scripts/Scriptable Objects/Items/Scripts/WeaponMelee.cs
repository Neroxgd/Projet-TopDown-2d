using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Melee", menuName = "Inventory System/Items/Weapon_Melee")]
public class WeaponMelee : ItemObject, IEquipable
{
    public int atkPower;
    public static bool isTypeEquiped;
    public float weaponSpeed;

    public override string TextInv()
    {
        return $"attack : +{atkPower}\n(Y) pour equiper l'objet\n(T) pour lacher l'objet";
    }

    void Awake()
    {
        isTypeEquiped = false;
    }

    bool IEquipable.GetTypeEquiped() { return isTypeEquiped; }

    void IEquipable.SetTypeEquiped(bool sign, SlotsManager slotsManager, InventorySlot inventorySlot) { isTypeEquiped = sign; }
    void IEquipable.SetStatsPlayer()
    {
        PlayerStatistic.Instance.AttackMelee = atkPower;
    }
    void IEquipable.ResetStatsPlayer()
    {
        PlayerStatistic.Instance.AttackMelee = 5;
    }
}
