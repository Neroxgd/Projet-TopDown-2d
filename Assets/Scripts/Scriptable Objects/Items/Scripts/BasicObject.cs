using UnityEngine;

[CreateAssetMenu(fileName = "New Basic Object", menuName = "Inventory System/Basic/Basic_Object")]
public class BasicObject : ItemObject
{
    public override string TextInv()
    {
        return $"(T) to drop item";
    }

    void Awake()
    {
        type = ItemType.Wood;
    }
}