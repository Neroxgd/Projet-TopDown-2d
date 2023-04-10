using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Sword1, Sword2, Sword3, Sword4,
    Bow1, Bow2, Bow3,
    HealthPotion,
    Torch1, Torch2, Lamp,
    Helmet1, Helmet2, Helmet3, Helmet4, Helmet5,
    Chestplate1, Chestplate2, Chestplate3, Chestplate4, Chestplate5,
    Wood,
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefabItem_UI;
    public GameObject prefab_World;
    public ItemType type;
    [TextArea(15, 20)] public string description;
    public bool isStackable;
    public int objectCount;
    public bool isEquipable;
    public bool isConsumable;

    public abstract string TextInv();
}
