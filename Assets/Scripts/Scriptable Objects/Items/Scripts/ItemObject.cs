using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Sword,
    HealtPotion,
    Torch,
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab_UI;
    public GameObject prefab_World;
    public ItemType type;
    [TextArea(15, 20)] public string description;
    public bool isStackable;
    public int objectCount;
    public bool isEquipable;

    public abstract string TextInv();
}
