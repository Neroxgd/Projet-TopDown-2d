using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory;
    [SerializeField] private Transform InstantiatHere;
    [SerializeField] private GameObject inv;
    [SerializeField] private Transform buttonSelect;
    public Transform ButtonSelect { get { return buttonSelect; } }
    [SerializeField] private Transform slot;
    [SerializeField] private GameObject buttonToInstanciat;
    public GameObject ButtonToInstanciat { get { return buttonToInstanciat; } }
    public Transform Slot { get { return slot; } }
    private bool afficheInv = false;
    public static UI_Inventory Instance { private set; get; }
    private List<GameObject> ui_InventoryObjectInstantiat;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AfficheInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            afficheInv = !afficheInv;
            inv.SetActive(afficheInv);
        }
    }

    public void UpdateInventory(ItemObject itemObject)
    {
        if (itemObject.isStackable)
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].item.type == itemObject.type)
                {

                    if (inventory.Container.Count > InstantiatHere.childCount)
                        Instantiate(itemObject.prefab, Vector3.zero, Quaternion.identity, InstantiatHere);
                    InstantiatHere.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
                    return;
                }
            }
        GameObject itemInstantiat = Instantiate(itemObject.prefab, Vector3.zero, Quaternion.identity, InstantiatHere);
        // ui_InventoryObjectInstantiat.Add(itemInstantiat);
        itemInstantiat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = 1.ToString();
    }

}