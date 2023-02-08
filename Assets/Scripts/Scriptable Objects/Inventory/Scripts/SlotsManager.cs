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
        if (IndexButton > -1 && context.started && inventory.Container[IndexButton].item is WeaponObject)
        {
            WeaponObject weaponObject = (WeaponObject)inventory.Container[IndexButton].item;
            if (!weaponObject.isEquiped)
            {
                PlayerStatistic.Instance.Attack = weaponObject.atkPower;
                for (int i = 0; i < inventory.Container.Count; i++)
                {
                    WeaponObject oldWeaponObject = inventory.Container[i].item as WeaponObject;
                    if (oldWeaponObject != null && oldWeaponObject.isEquiped)
                    {
                        oldWeaponObject.isEquiped = false;
                        transform.GetChild(i).GetComponent<Image>().color = Color.white;
                        break;
                    }
                }
                transform.GetChild(IndexButton).GetComponent<Image>().color = colorEquiped;
                weaponObject.isEquiped = true;
                print("jeuaa");
            }
            else
            {
                PlayerStatistic.Instance.Attack -= weaponObject.atkPower;
                transform.GetChild(IndexButton).GetComponent<Image>().color = Color.white;
                weaponObject.isEquiped = false;
            }
        }
    }

    public void Desappears()
    {
        textDrop.text = "";
    }

    public void Equipable()
    {
        textDrop.text += "(Y) to equipe item\n";
    }

    public void Drop()
    {
        textDrop.text += "(T) to drop item";
    }
}
