using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemObject _item;
    public ItemObject _Item { get { return _item; } }
}
