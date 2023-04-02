using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemObject item;
    public ItemObject _Item { get { return item; } }
}
