using UnityEngine;

public class ReparBidge : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventoryObject;
    [SerializeField] private UI_Inventory _uiInventory;
    [SerializeField] private GameObject tilmMapBridgeRepared;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            for (int i = 0; i < _inventoryObject.Container.Count; i++)
                if (_inventoryObject.Container[i].item.type == ItemType.Wood && _inventoryObject.Container[i].amount >= 5)
                {
                    tilmMapBridgeRepared.SetActive(true);
                    _inventoryObject.Container[i].amount -= 5;
                    _uiInventory.UpdateInventory(_inventoryObject.Container[i].item);
                    Destroy(transform.parent.gameObject);
                }
    }
}
