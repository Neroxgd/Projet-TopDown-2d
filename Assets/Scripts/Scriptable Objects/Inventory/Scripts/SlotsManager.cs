using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using DG.Tweening;

public class SlotsManager : MonoBehaviour
{
    public InventoryObject inventory;
    [SerializeField] private TextMeshProUGUI warningMessage;
    public UI_Inventory uI_Inventory;
    public GameObject prefabSlot;
    public Transform world;
    public int IndexButton { get; set; } = -1;
    [SerializeField] private TextMeshProUGUI textItem, textStatsATKMelee, textStatsATKDistance, textStatsDEF;
    [SerializeField] private Color colorEquiped = Color.green;
    public GameObject uIAmmo;
    public PlayerLight playerLight;

    public void DropItem(InputAction.CallbackContext context)
    {
        if (IndexButton > -1 && context.started)
        {
            if (inventory.Container[IndexButton].isEquiped)
            {
                AlertMessage("you can't drop it while it's equipped");
                return;
            }
            Instantiate(inventory.Container[IndexButton].item.prefab_World, PlayerStatistic.Instance.transform.position - Vector3.down, Quaternion.identity, world);
            if (inventory.Container[IndexButton].amount > 1)
            {
                inventory.Container[IndexButton].amount--;
                uI_Inventory.UpdateInventory(inventory.Container[IndexButton].item);
                return;
            }
            Destroy(transform.GetChild(IndexButton).gameObject);
            Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, transform);
            inventory.Container.RemoveAt(IndexButton);
            IndexButton = -1;
            Desappears();
            uI_Inventory.InstantiatCount--;
        }
    }
    //j'ai refactor tout le script grace aux interface, l'ancienne version est tout en bas
    public void EquipeItem(InputAction.CallbackContext context)
    {
        if (IndexButton > -1 && context.started && inventory.Container[IndexButton].item.isEquipable)
        {
            IEquipable equipableObj = inventory.Container[IndexButton].item as IEquipable;
            if (!inventory.Container[IndexButton].isEquiped && equipableObj != null)
            {
                equipableObj.SetStatsPlayer();
                if (equipableObj.GetTypeEquiped())
                    for (int i = 0; i < inventory.Container.Count; i++)
                    {
                        if (inventory.Container[i].isEquiped && inventory.Container[i] != inventory.Container[IndexButton] && inventory.Container[i].item.GetType() == inventory.Container[IndexButton].item.GetType())
                        {
                            inventory.Container[i].isEquiped = false;
                            transform.GetChild(i).GetComponent<Image>().color = Color.white;
                            break;
                        }
                    }
                equipableObj.SetTypeEquiped(true, this, inventory.Container[IndexButton]);
                transform.GetChild(IndexButton).GetComponent<Image>().color = colorEquiped;
                inventory.Container[IndexButton].isEquiped = true;
            }
            else
            {
                equipableObj.ResetStatsPlayer();
                equipableObj.SetTypeEquiped(false, this, inventory.Container[IndexButton]);
                transform.GetChild(IndexButton).GetComponent<Image>().color = Color.white;
                inventory.Container[IndexButton].isEquiped = false;
            }
            UpdateShowStats();
        }
    }

    public void ConsumeItem(InputAction.CallbackContext context)
    {
        if (IndexButton > -1 && context.started && inventory.Container[IndexButton].item.isConsumable)
        {
            HealthPotionObject healthPotionObject = inventory.Container[IndexButton].item as HealthPotionObject;
            if (healthPotionObject != null)
                PlayerStatistic.Instance.transform.GetComponent<PlayerLife>().TakeDamage(-healthPotionObject.health);
            if (inventory.Container[IndexButton].amount > 1)
            {
                inventory.Container[IndexButton].amount--;
                uI_Inventory.UpdateInventory(inventory.Container[IndexButton].item);
                return;
            }
            Destroy(transform.GetChild(IndexButton).gameObject);
            Instantiate(prefabSlot, Vector3.zero, Quaternion.identity, transform);
            inventory.Container.RemoveAt(IndexButton);
            IndexButton = -1;
            Desappears();
            uI_Inventory.InstantiatCount--;
        }
    }

    public void Desappears()
    {
        textItem.text = "";
    }

    public void ShowTextInventory(string textToShow)
    {
        textItem.text += textToShow;
    }

    private void UpdateShowStats()
    {
        textStatsATKMelee.text = "atk melee : " + PlayerStatistic.Instance.AttackMelee.ToString();
        textStatsATKDistance.text = "atk distance : " + PlayerStatistic.Instance.AttackDistance.ToString();
        textStatsDEF.text = "def : " + PlayerStatistic.Instance.TotalArmor.ToString();
    }

    public void AlertMessage(string message)
    {
        warningMessage.alpha = 1;
        warningMessage.text = message;
        warningMessage.DOFade(0, 5).OnComplete(() => warningMessage.text = "");
    }

    // public void EquipeItem(InputAction.CallbackContext context)
    // {
    //     if (IndexButton > -1 && context.started && inventory.Container[IndexButton].item.isEquipable)
    //     {
    //         WeaponMelee weaponMelee = inventory.Container[IndexButton].item as WeaponMelee;
    //         LightObject lightObject = inventory.Container[IndexButton].item as LightObject;
    //         Armor_HelmetObject helmetObject = inventory.Container[IndexButton].item as Armor_HelmetObject;
    //         Armor_ChestplateObject chestplateObject = inventory.Container[IndexButton].item as Armor_ChestplateObject;
    //         WeaponDistance weaponDistance = inventory.Container[IndexButton].item as WeaponDistance;
    //         //add all cast
    //         if (!inventory.Container[IndexButton].isEquiped)
    //         {
    //             if (weaponMelee != null)
    //                 PlayerStatistic.Instance.AttackMelee = weaponMelee.atkPower;
    //             else if (weaponDistance != null)
    //                 PlayerStatistic.Instance.AttackDistance = weaponDistance.atkPower;
    //             else if (helmetObject != null)
    //                 PlayerStatistic.Instance.Armor_Helmet = helmetObject.defPower;
    //             else if (chestplateObject != null)
    //                 PlayerStatistic.Instance.Armor_Chestplate = chestplateObject.defPower;
    //             if ((weaponMelee != null && WeaponMelee.isTypeEquiped) || (lightObject != null && LightObject.isTypeEquiped) || (helmetObject != null && Armor_HelmetObject.isTypeEquiped) || (chestplateObject != null && Armor_ChestplateObject.isTypeEquiped) || (weaponDistance != null && WeaponDistance.isTypeEquiped)/* || add all cast*/)
    //                 for (int i = 0; i < inventory.Container.Count; i++)
    //                 {
    //                     if (inventory.Container[i].isEquiped && inventory.Container[i] != inventory.Container[IndexButton] && inventory.Container[i].item.GetType() == inventory.Container[IndexButton].item.GetType())
    //                     {
    //                         inventory.Container[i].isEquiped = false;
    //                         transform.GetChild(i).GetComponent<Image>().color = Color.white;
    //                         break;
    //                     }
    //                 }
    //             if (weaponMelee != null)
    //                 WeaponMelee.isTypeEquiped = true;
    //             else if (weaponDistance != null)
    //             {
    //                 WeaponDistance.isTypeEquiped = true;
    //                 uIAmmo.SetActive(true);
    //             }
    //             else if (lightObject != null)
    //                 LightObject.isTypeEquiped = true;
    //             else if (helmetObject != null)
    //                 Armor_HelmetObject.isTypeEquiped = true;
    //             else if (chestplateObject != null)
    //                 Armor_ChestplateObject.isTypeEquiped = true;
    //             transform.GetChild(IndexButton).GetComponent<Image>().color = colorEquiped;
    //             inventory.Container[IndexButton].isEquiped = true;
    //         }
    //         else
    //         {
    //             if (weaponMelee != null)
    //             {
    //                 PlayerStatistic.Instance.AttackMelee = 5;
    //                 WeaponMelee.isTypeEquiped = false;
    //             }
    //             else if (weaponDistance != null)
    //             {
    //                 PlayerStatistic.Instance.AttackDistance = 0;
    //                 WeaponDistance.isTypeEquiped = false;
    //                 uIAmmo.SetActive(false);
    //             }
    //             else if (lightObject != null)
    //                 LightObject.isTypeEquiped = false;
    //             else if (helmetObject != null)
    //             {
    //                 PlayerStatistic.Instance.Armor_Helmet = 0;
    //                 Armor_HelmetObject.isTypeEquiped = false;
    //             }
    //             else if (chestplateObject != null)
    //             {
    //                 PlayerStatistic.Instance.Armor_Chestplate = 0;
    //                 Armor_ChestplateObject.isTypeEquiped = false;
    //             }
    //             transform.GetChild(IndexButton).GetComponent<Image>().color = Color.white;
    //             inventory.Container[IndexButton].isEquiped = false;
    //         }
    //         UpdateShowStats();
    //     }
    // }

}
