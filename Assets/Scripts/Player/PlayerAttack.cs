using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;
    [SerializeField] private GameObject prefabAtkMelee, prefabAtkDistance, prefabAmmo;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private InventoryObject inventoryObject;
    [SerializeField, Range(0.1f, 1)] private float atkDefaultWeaponSpeed = 0.5f;
    [SerializeField] private float speedAmmo = 2f;
    private float atkSpeed;
    private bool canAttack = true;

    void Start()
    {
        PlayerStatistic.Instance.Attack = 5;
    }

    public void InputAttackMelee(InputAction.CallbackContext context)
    {
        if (context.started && !uI_Inventory.ShowInventory && canAttack)
            StartCoroutine(AttackMelee());
    }

    public void InputAttackDistance(InputAction.CallbackContext context)
    {
        if (context.started && !uI_Inventory.ShowInventory && canAttack && WeaponDistance.isTypeEquiped)
            StartCoroutine(AttackDistance());
    }

    IEnumerator AttackMelee()
    {
        canAttack = false;
        GameObject atk = Instantiate(prefabAtkMelee, transform.position, Quaternion.identity, transform);
        atk.transform.rotation = Utils.LookAt2D(atk.transform.rotation, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position);
        if (WeaponMelee.isTypeEquiped)
            for (int i = 0; i < inventoryObject.Container.Count; i++)
            {
                WeaponMelee weaponMelee = inventoryObject.Container[i].item as WeaponMelee;
                if (inventoryObject.Container[i].isEquiped && weaponMelee != null)
                {
                    atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaponMelee.prefab_World.GetComponent<SpriteRenderer>().sprite;
                    atkSpeed = weaponMelee.weaponSpeed;
                    break;
                }
            }
        else
        {
            atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = defaultSprite;
            atkSpeed = atkDefaultWeaponSpeed;
            atk.transform.localScale /= 1.5f;
        }
        atk.transform.eulerAngles = new Vector3(atk.transform.eulerAngles.x, atk.transform.eulerAngles.y, atk.transform.eulerAngles.z + -45);
        atk.transform.DORotate(new Vector3(0, 0, 90), atkSpeed, RotateMode.WorldAxisAdd);
        yield return new WaitForSeconds(atkSpeed);
        canAttack = true;
        Destroy(atk);
    }

    IEnumerator AttackDistance()
    {
        canAttack = false;
        GameObject atk = Instantiate(prefabAtkDistance, transform.position, Quaternion.identity, transform);
        atk.transform.rotation = Utils.LookAt2D(atk.transform.rotation, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position);
        for (int i = 0; i < inventoryObject.Container.Count; i++)
        {
            WeaponDistance weaponDistance = inventoryObject.Container[i].item as WeaponDistance;
            if (inventoryObject.Container[i].isEquiped && weaponDistance != null)
            {
                atk.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaponDistance.prefab_World.GetComponent<SpriteRenderer>().sprite;
                atkSpeed = weaponDistance.weaponSpeed;
                break;
            }
        }
        GameObject ammo = Instantiate(prefabAmmo, transform.position, atk.transform.rotation, transform);
        ammo.transform.DOMove(ammo.transform.position + ammo.transform.up * 50, speedAmmo)
        .SetSpeedBased(true)
        .SetEase(Ease.Linear)
        .OnComplete(() => Destroy(ammo));
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
