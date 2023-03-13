using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;
    [SerializeField] private GameObject prefabAtk;
    [SerializeField] private InventoryObject inventoryObject;
    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.started && !uI_Inventory.ShowInventory) return;
        StartCoroutine(AttackMelee());
    }

    IEnumerator AttackMelee()
    {
        GameObject atk = Instantiate(prefabAtk, transform.position, Quaternion.identity, transform);
        Vector3 diff = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        atk.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        atk.transform.Translate(transform.up / 2);
        for (int i = 0; i < inventoryObject.Container.Count; i++)
            if (inventoryObject.Container[i].isEquiped && inventoryObject.Container[i].item is WeaponObject)
                atk.GetComponent<SpriteRenderer>().sprite = inventoryObject.Container[i].item.prefab_World.GetComponent<SpriteRenderer>().sprite;
                yield return new WaitForSeconds(0.5f);
        Destroy(atk);
    }
}
