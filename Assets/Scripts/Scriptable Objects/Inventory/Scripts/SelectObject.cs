using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour/*, ISerializationCallbackReceiver*/
{
    private GetReferenceForButton RefButton;
    // [SerializeField] private Transform slot;
    // [SerializeField] private List<ItemType> keys = new List<ItemType>();
    // [SerializeField] private List<GameObject> values = new List<GameObject>();
    // private Dictionary<ItemType, GameObject> referenceGameObjectInWorld = new Dictionary<ItemType, GameObject>();
    // public bool modifyValues;
    // private Button button;
    private int indexButton = -1;
    void Start()
    {
        RefButton = transform.parent.parent.GetComponent<GetReferenceForButton>();
    }
    public void DropItem()
    {
        for (int i = 0; i < RefButton.inventory.Container.Count - 1; i++)
        {
            if (transform.parent.parent.GetChild(i) == transform.parent)
            {
                indexButton = i;
                print("bzzz");
                break;
            }
        }

        if (indexButton > -1)
        {

            Instantiate(RefButton.inventory.Container[indexButton].item.prefab_World, RefButton.player.position - Vector3.down, Quaternion.identity, RefButton.world);
            Destroy(transform.parent.GetChild(1));
            RefButton.inventory.Container.RemoveAt(indexButton);
            
            // GameObject prefabToInstance;
            // if (inventory.referenceGameObjectInWorld.TryGetValue(inventory.Container[indexButton].item.type, out prefabToInstance))
            // {
            //     Instantiate(prefabToInstance, player.position - transform.up * 5, Quaternion.identity, world);
            //     Destroy(slot.GetChild(indexButton));
            // }
        }
    }

    // public void OnBeforeSerialize()
    // {
    //     if (!modifyValues)
    //     {
    //         keys.Clear();
    //         values.Clear();

    //         for (int i = 0; i < Mathf.Min(inventory.keys.Count, inventory.values.Count); i++)
    //         {
    //             keys.Add(inventory.keys[i]);
    //             values.Add(inventory.values[i]);
    //         }
    //     }
    // }

    // public void OnAfterDeserialize()
    // {
    // }

    // public void DeserializeDictionary()
    // {
    //     referenceGameObjectInWorld = new Dictionary<ItemType, GameObject>();
    //     inventory.keys.Clear();
    //     inventory.values.Clear();
    //     for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
    //     {
    //         inventory.keys.Add(keys[i]);
    //         inventory.values.Add(values[i]);
    //         referenceGameObjectInWorld.Add(keys[i], values[i]);
    //     }
    //     modifyValues = false;
    // }
}
