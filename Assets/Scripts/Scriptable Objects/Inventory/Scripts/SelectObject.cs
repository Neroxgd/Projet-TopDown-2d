using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private SlotsManager _slotsManager;

    void Start()
    {
        _slotsManager = transform.parent.parent.GetComponent<SlotsManager>();
    }

    public void InitializeIndex()
    {
        for (int i = 0; i < _slotsManager.inventory.Container.Count; i++)
        {
            if (transform.parent.parent.GetChild(i) == transform.parent)
            {
                _slotsManager.Desappears();
                _slotsManager.IndexButton = i;
                _slotsManager.ShowTextInventory(_slotsManager.inventory.Container[i].item.TextInv());
                break;
            }
            else
            {
                _slotsManager.IndexButton = -1;
                _slotsManager.Desappears();
            }
        }
    }
}
