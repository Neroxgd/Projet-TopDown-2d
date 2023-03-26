using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            if (item._item.isStackable)
            {
                inventory.AddItem(item._item, item._item.objectCount);
                UI_Inventory.Instance.UpdateInventory(item._item);
            }
            else
                for (int i = 0; i < item._item.objectCount; i++)
                {
                    inventory.AddItem(item._item, 1);
                    UI_Inventory.Instance.UpdateInventory(item._item);
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
        inventory.Container.Clear();
    }
}
