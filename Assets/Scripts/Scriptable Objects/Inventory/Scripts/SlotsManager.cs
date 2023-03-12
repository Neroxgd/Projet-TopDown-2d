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
            WeaponObject weaponObject = inventory.Container[IndexButton].item as WeaponObject;
            LightObject lightObject = inventory.Container[IndexButton].item as LightObject;
            ItemObject globalObject = null;
            if (weaponObject != null)
                globalObject = weaponObject;
            else if (lightObject != null)
                globalObject = lightObject;
            //add all cast
            if (!inventory.Container[IndexButton].isEquiped)
            {
                if (weaponObject != null)
                    PlayerStatistic.Instance.Attack = weaponObject.atkPower;
                if ((weaponObject != null && weaponObject.isTypeEquiped) || (lightObject != null && lightObject.isTypeEquiped)/* || add all cast*/)
                    for (int i = 0; i < inventory.Container.Count; i++)
                    {
                        if (inventory.Container[i].isEquiped && inventory.Container[i] != inventory.Container[IndexButton] && globalObject == inventory.Container[i].item)
                        {
                            inventory.Container[i].isEquiped = false;
                            transform.GetChild(i).GetComponent<Image>().color = Color.white;
                            break;
                        }
                    }
                if (weaponObject != null)
                    weaponObject.isTypeEquiped = true;
                else if (lightObject != null)
                    lightObject.isTypeEquiped = true;
                transform.GetChild(IndexButton).GetComponent<Image>().color = colorEquiped;
                inventory.Container[IndexButton].isEquiped = true;
            }
            else
            {
                if (weaponObject != null)
                {
                    PlayerStatistic.Instance.Attack -= weaponObject.atkPower;
                    weaponObject.isTypeEquiped = false;
                }
                if (lightObject != null)
                    lightObject.isTypeEquiped = false;
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
