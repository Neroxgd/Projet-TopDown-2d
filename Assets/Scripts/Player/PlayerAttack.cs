using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;
    [SerializeField] private GameObject prefabAtk;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private InventoryObject inventoryObject;
    [SerializeField, Range(0.1f, 1)] private float atkDefaultWeaponSpeed = 0.5f;
    private float atkSpeed;
    private bool canAttack = true;
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started && !uI_Inventory.ShowInventory && canAttack)
            StartCoroutine(AttackMelee());
    }

    IEnumerator AttackMelee()
    {
        canAttack = false;
        GameObject atk = Instantiate(prefabAtk, transform.position, Quaternion.identity, transform);
        Vector3 diff = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        atk.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        // atk.transform.Translate((transform.up) / 2f);
        for (int i = 0; i <= inventoryObject.Container.Count; i++)
        {
            if (i != inventoryObject.Container.Count && inventoryObject.Container[i].isEquiped && inventoryObject.Container[i].item is WeaponObject)
            {
                atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = inventoryObject.Container[i].item.prefab_World.GetComponent<SpriteRenderer>().sprite;
                atkSpeed = ((WeaponObject)inventoryObject.Container[i].item).weaponSpeed;
                break;
            }
            if (i == inventoryObject.Container.Count)
            {
                atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = defaultSprite;
                atkSpeed = atkDefaultWeaponSpeed;
                atk.transform.localScale /= 1.5f;
            }
        }
        atk.transform.eulerAngles = new Vector3(atk.transform.eulerAngles.x, atk.transform.eulerAngles.y, atk.transform.eulerAngles.z + -45);
        atk.transform.DORotate(new Vector3(0, 0, 90), atkSpeed, RotateMode.WorldAxisAdd);
        yield return new WaitForSeconds(atkSpeed);
        canAttack = true;
        Destroy(atk);
    }
}