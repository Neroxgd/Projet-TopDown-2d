using UnityEngine;

[CreateAssetMenu(fileName = "New Health_Potion Object", menuName = "Inventory System/Consumable/Health_Potion")]
public class HealthPotionObject : ItemObject
{
    public float health; 

    public override string TextInv()
    {
        return $"health : +{health}\n(Y) pour utiliser l'objet\n(T) pour lacher l'objet";
    }
}
