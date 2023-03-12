using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class SlotsManager : MonoBehaviour
{
    public InventoryObject inventory;
    public UI_Inventory uI_Inventory;
    public GameObject prefabSlot;
    public Transform player;
    public Transform world;
    public int IndexButton { get; set; } = -1;
    [SerializeField] private TextMeshProUGUI textDrop;
    [SerializeField] private Color colorEquiped = Color.green;

    public void DropItem(InputAction.CallbackContext context)
    {
        if (IndexButton > -1 && context.started)
        {
            Instantiate(inventory.Container[IndexButton].item.prefab_World, player.position - Vector3.down, Quaternion.identity, world);
            Destroy(transform.GetChild(IndexButton).gameObject);
            Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, transform);
            inventory.Container.RemoveAt(IndexButton);
            IndexButton = -1;
            Desappears();
            uI_Inventory.InstantiatCount--;
        }
    }

    public void EquipeItem(InputAction.CallbackContext context)
    {
        if (IndexButton > -1 && context.started && inventory.Container[IndexButton].item.isEquipable)
        {
            // WeaponObject weaponObject = (WeaponObject)inventory.Container[IndexButton].item;
            if (!inventory.Container[IndexButton].isEquiped)
            {
                // PlayerStatistic.Instance.Attack = weaponObject.atkPower;
                for (int i = 0; i < inventory.Container.Count; i++)
                {
                    // WeaponObject oldWeaponObject = inventory.Container[i].item as WeaponObject;
                    if (inventory.Container[i].isEquiped && inventory.Container[i] != inventory.Container[IndexButton])
                    {
                        inventory.Container[i].isEquiped = false;
                        transform.GetChild(i).GetComponent<Image>().color = Color.white;
                        break;
                    }
                }
                transform.GetChild(IndexButton).GetComponent<Image>().color = colorEquiped;
                inventory.Container[IndexButton].isEquiped = true;
            }
            else
            {
                // PlayerStatistic.Instance.Attack -= weaponObject.atkPower;
                transform.GetChild(IndexButton).GetComponent<Image>().color = Color.white;
                inventory.Container[IndexButton].isEquiped = false;
                
            }
        }
    }

    public void Desappears()
    {
        textDrop.text = "";
    }

    public void ShowTextInventory(string textToShow)
    {
        textDrop.text += textToShow;
    }
}
