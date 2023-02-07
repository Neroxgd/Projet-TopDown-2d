using System.Collections;
using System.Collections.Generic;
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
    public int IndexButton { get; set;} = -1;
    [SerializeField] private TextMeshProUGUI textDrop;

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
