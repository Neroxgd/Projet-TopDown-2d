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

    void Start()
    {
        PlayerStatistic.Instance.Attack = 5;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started && !uI_Inventory.ShowInventory && canAttack)
        {
            // if (inventoryObject.Container)
            StartCoroutine(AttackMelee());
        }

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
        if (!WeaponMelee.isTypeEquiped)
        {
            atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = defaultSprite;
            atkSpeed = atkDefaultWeaponSpeed;
            atk.transform.localScale /= 1.5f;
        }
        else
            for (int i = 0; i < inventoryObject.Container.Count; i++)
            {
                WeaponMelee weaponMelee = inventoryObject.Container[i].item as WeaponMelee;
                if (inventoryObject.Container[i].isEquiped && weaponMelee != null)
                {
                    atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = inventoryObject.Container[i].item.prefab_World.GetComponent<SpriteRenderer>().sprite;
                    atkSpeed = weaponMelee.weaponSpeed;
                    break;
                }
            }
        atk.transform.eulerAngles = new Vector3(atk.transform.eulerAngles.x, atk.transform.eulerAngles.y, atk.transform.eulerAngles.z + -45);
        atk.transform.DORotate(new Vector3(0, 0, 90), atkSpeed, RotateMode.WorldAxisAdd);
        yield return new WaitForSeconds(atkSpeed);
        canAttack = true;
        Destroy(atk);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Entity"))
            other.GetComponent<IA>().IALife -= PlayerStatistic.Instance.Attack;
    }
}
