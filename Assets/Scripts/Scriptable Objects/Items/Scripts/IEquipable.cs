public interface IEquipable
{
    void SetStatsPlayer();
    void ResetStatsPlayer();
    bool GetTypeEquiped();
    void SetTypeEquiped(bool sign, SlotsManager slotsManager, InventorySlot inventorySlot);
}