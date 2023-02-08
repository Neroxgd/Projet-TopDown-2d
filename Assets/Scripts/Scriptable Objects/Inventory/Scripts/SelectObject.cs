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
                if(_slotsManager.inventory.Container[i].item is WeaponObject)
                {
                    // WeaponObject weaponObject = (WeaponObject)_slotsManager.inventory.Container[i].item;
                    _slotsManager.Equipable();
                }

                if (_slotsManager.inventory.Container[i].item is LightObject)
                {
                    
                }
                _slotsManager.Drop();
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
