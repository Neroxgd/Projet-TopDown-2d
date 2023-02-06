using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GetReferenceForButton : MonoBehaviour
{
    public InventoryObject inventory;
    public UI_Inventory uI_Inventory;
    public GameObject prefabSlot;
    public Transform player;
    public Transform world;
    private int indexButton = -1;
    public int IndexButton { get { return indexButton; } set { indexButton = value; } }
    [SerializeField] private TextMeshProUGUI textDrop;

    public void DropItem(InputAction.CallbackContext context)
    {
        if (indexButton > -1 && context.started)
        {
            Instantiate(inventory.Container[indexButton].item.prefab_World, player.position - Vector3.down, Quaternion.identity, world);
            Destroy(transform.GetChild(indexButton).gameObject);
            Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, transform);
            inventory.Container.RemoveAt(indexButton);
            indexButton = -1;
            textDrop.text = "";
            uI_Inventory.InstantiatCount--;
        }
    }

    public void TextDropItem(bool affiche)
    {
        if (affiche)
            textDrop.text = "(T) for drop item";
        else
            textDrop.text = "";
    }
}
