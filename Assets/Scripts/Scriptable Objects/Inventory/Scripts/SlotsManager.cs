using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SlotsManager : MonoBehaviour
{
    public InventoryObject inventory;
    public UI_Inventory uI_Inventory;
    public GameObject prefabSlot;
    public Transform world;
    public int IndexButton { get; set; } = -1;
    [SerializeField] private TextMeshProUGUI textItem, textStatsATK, textStatsDEF;
    [SerializeField] private Color colorEquiped = Color.green;

    public void DropItem(InputAction.CallbackContext context)
    {
        if (IndexButton > -1 && context.started)
        {
            Instantiate(inventory.Container[IndexButton].item.prefab_World, PlayerStatistic.Instance.transform.position - Vector3.down, Quaternion.identity, world);
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
            Armor_HelmetObject helmetObject = inventory.Container[IndexButton].item as Armor_HelmetObject;
            Armor_ChestplateObject chestplateObject = inventory.Container[IndexButton].item as Armor_ChestplateObject;
            ItemObject globalObject = null;
            if (weaponObject != null)
                globalObject = weaponObject;
            else if (lightObject != null)
                globalObject = lightObject;
            else if (helmetObject != null)
                globalObject = helmetObject;
            else if (chestplateObject)
                globalObject = chestplateObject;
            //add all cast
            if (!inventory.Container[IndexButton].isEquiped)
            {
                if (weaponObject != null)
                    PlayerStatistic.Instance.Attack = weaponObject.atkPower;
                else if (helmetObject != null)
                    PlayerStatistic.Instance.Armor_Helmet = helmetObject.defPower;
                else if (chestplateObject != null)
                    PlayerStatistic.Instance.Armor_Chestplate = chestplateObject.defPower;
                if ((weaponObject != null && weaponObject.isTypeEquiped) || (lightObject != null && lightObject.isTypeEquiped) || (helmetObject != null && helmetObject.isTypeEquiped) || (chestplateObject != null && chestplateObject.isTypeEquiped)/* || add all cast*/)
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
                else if (helmetObject != null)
                    helmetObject.isTypeEquiped = true;
                else if (chestplateObject != null)
                    chestplateObject.isTypeEquiped = true;
                transform.GetChild(IndexButton).GetComponent<Image>().color = colorEquiped;
                inventory.Container[IndexButton].isEquiped = true;
            }
            else
            {
                if (weaponObject != null)
                {
                    PlayerStatistic.Instance.Attack = 5;
                    weaponObject.isTypeEquiped = false;
                }
                else if (lightObject != null)
                    lightObject.isTypeEquiped = false;
                else if (helmetObject != null)
                {
                    PlayerStatistic.Instance.Armor_Helmet = 0;
                    helmetObject.isTypeEquiped = false;
                }
                else if (chestplateObject != null)
                {
                    PlayerStatistic.Instance.Armor_Chestplate = 0;
                    chestplateObject.isTypeEquiped = false;
                }
                transform.GetChild(IndexButton).GetComponent<Image>().color = Color.white;
                inventory.Container[IndexButton].isEquiped = false;
            }
            UpdateShowStats();
        }
    }

    public void Desappears()
    {
        textItem.text = "";
    }

    public void ShowTextInventory(string textToShow)
    {
        textItem.text += textToShow;
    }

    private void UpdateShowStats()
    {
        textStatsATK.text = "atk : " + PlayerStatistic.Instance.Attack.ToString();
        textStatsDEF.text = "def : " + PlayerStatistic.Instance.TotalArmor.ToString();
    }
}
