using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private InventoryObject _inventory;
    [SerializeField] private Transform InstantiatHere;
    [SerializeField] private SlotsManager _slotsManager;
    [SerializeField] private AudioClip openInventory;
    private int instantiatCount = 0;
    public int InstantiatCount { get { return instantiatCount; } set { instantiatCount = value; } }
    [SerializeField] private GameObject inv;
    // [SerializeField] private Transform buttonSelect;
    // public Transform ButtonSelect { get { return buttonSelect; } }
    // [SerializeField] private Transform slot;
    // [SerializeField] private GameObject buttonToInstanciat;
    // public GameObject ButtonToInstanciat { get { return buttonToInstanciat; } }
    // public Transform Slot { get { return slot; } }
    public bool ShowInventory { get; private set; } = false;
    public static UI_Inventory Instance { private set; get; }
    // private List<GameObject> ui_InventoryObjectInstantiat;

    void Awake()
    {
        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void AfficheInventory(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ShowInventory = !ShowInventory;
            inv.SetActive(ShowInventory);
            AudioManager.Instance.PlayAudioSound(openInventory);
            if (!ShowInventory)
            {  
                _slotsManager.IndexButton = -1;
                _slotsManager.Desappears();
            }
        }
    }

    public void UpdateInventory(ItemObject itemObject)
    {
        if (itemObject.isStackable)
            for (int i = 0; i < _inventory.Container.Count; i++)
            {
                if (_inventory.Container[i].item.type == itemObject.type)
                {
                    if (_inventory.Container.Count > instantiatCount)
                    {
                        GameObject itemUI = Instantiate(itemObject.prefabItem_UI, InstantiatHere.GetChild(instantiatCount).position, Quaternion.identity, InstantiatHere.GetChild(instantiatCount));
                        itemUI.GetComponent<Image>().sprite = itemObject.prefab_World.GetComponent<SpriteRenderer>().sprite;
                        itemUI.GetComponent<Image>().color = itemObject.prefab_World.GetComponent<SpriteRenderer>().color;
                        instantiatCount++;
                    }
                    InstantiatHere.GetChild(i).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = _inventory.Container[i].amount.ToString();
                    return;
                }
            }
        GameObject itemInstantiat = Instantiate(itemObject.prefabItem_UI, InstantiatHere.GetChild(instantiatCount).position, Quaternion.identity, InstantiatHere.GetChild(instantiatCount));
        itemInstantiat.GetComponent<Image>().sprite = itemObject.prefab_World.GetComponent<SpriteRenderer>().sprite;
        itemInstantiat.GetComponent<Image>().color = itemObject.prefab_World.GetComponent<SpriteRenderer>().color;
        instantiatCount++;
        // ui_InventoryObjectInstantiat.Add(itemInstantiat);
        itemInstantiat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "1";
    }

}
