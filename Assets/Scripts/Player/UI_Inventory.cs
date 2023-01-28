using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private InventoryObject inventory;
    [SerializeField] private Transform InstantiatHere;
    public static UI_Inventory Instance {private set; get;}

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateInventory(ItemObject itemObject)
    {
        GameObject item = Instantiate(itemObject.prefab, Vector3.zero, Quaternion.identity, InstantiatHere);
    }
}
