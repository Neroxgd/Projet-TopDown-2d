using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventory;
    [SerializeField] private AudioClip pickUpSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            AudioManager.Instance.PlayAudioSound(pickUpSound);
            if (item._Item.isStackable)
            {
                _inventory.AddItem(item._Item, item._Item.objectCount);
                UI_Inventory.Instance.UpdateInventory(item._Item);
            }
            else
                for (int i = 0; i < item._Item.objectCount; i++)
                {
                    _inventory.AddItem(item._Item, 1);
                    UI_Inventory.Instance.UpdateInventory(item._Item);
                }
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        // for (int i = 0; i < inventory.Container.Count; i++)
        // {
        //     var oldWeaponObject = inventory.Container[i].item as WeaponObject;
        //     if (oldWeaponObject != null && oldWeaponObject.isEquiped)
        //         oldWeaponObject.isEquiped = false;
        // }
        _inventory.Container.Clear();
    }
}
