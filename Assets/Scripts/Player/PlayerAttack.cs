using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using TMPro;
using Nerox_gd;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private UI_Inventory uI_Inventory;
    [SerializeField] private GameObject prefabAtkMelee, prefabAtkDistance, prefabAmmo;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private InventoryObject inventoryObject;
    [SerializeField, Range(0.1f, 1)] private float atkDefaultWeaponSpeed = 0.5f;
    [SerializeField] private float speedAmmo = 2f;
    [SerializeField] private TextMeshProUGUI ammoUI;
    [SerializeField] private AudioClip atkMelee, atkDistance;
    private int ammoCount;
    public int AmmoCount
    {
        get { return ammoCount; }
        set
        {
            ammoCount = value;
            ammoUI.text = ammoCount.ToString();
        }
    }

    private float atkSpeed;
    public bool CanAttack { get; private set; } = true;

    void Start()
    {
        PlayerStatistic.Instance.AttackMelee = 5;
    }

    void LateUpdate()
    {
        // if (!IA.isChasingPlayer && AudioManager.Instance.cashMusic != AudioManager.Instance.audioSource.clip)
        // {
        //     AudioManager.Instance.PlayCashMusic();
        //     print("zefzef");
        // }  
    }

    public void InputAttackMelee(InputAction.CallbackContext context)
    {
        if (context.started && !uI_Inventory.ShowInventory && CanAttack)
            StartCoroutine(AttackMelee());
    }

    public void InputAttackDistance(InputAction.CallbackContext context)
    {
        if (context.started && !uI_Inventory.ShowInventory && CanAttack && WeaponDistance.isTypeEquiped)
            StartCoroutine(AttackDistance());
    }

    IEnumerator AttackMelee()
    {
        AudioManager.Instance.PlayAudioSound(atkMelee);
        CanAttack = false;
        GameObject atk = Instantiate(prefabAtkMelee, transform.position, Quaternion.identity, transform);
        atk.transform.rotation = Pratique.LookAtMouse2D(atk.transform);
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
        CanAttack = true;
        Destroy(atk);
    }

    IEnumerator AttackDistance()
    {
        AudioManager.Instance.PlayAudioSound(atkDistance);
        CanAttack = false;
        GameObject atk = Instantiate(prefabAtkDistance, transform.position, Quaternion.identity, transform);
        atk.transform.rotation = Pratique.LookAt2D(atk.transform.rotation, Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position);
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
        if (ammoCount <= 0)
        {
            yield return new WaitForSeconds(atkSpeed);
            CanAttack = true;
            Destroy(atk);
            yield break;
        }
        GameObject ammo = Instantiate(prefabAmmo, transform.position, atk.transform.rotation, transform);
        ammo.GetComponent<Rigidbody2D>().DOMove(ammo.transform.position + ammo.transform.up * 50, speedAmmo)
        .SetSpeedBased(true)
        .SetEase(Ease.Linear)
        .OnComplete(() => Destroy(ammo));
        AmmoCount--;
        yield return new WaitForSeconds(atkSpeed);
        CanAttack = true;
        Destroy(atk);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Entity") && !CanAttack)
            other.GetComponent<IA>().IALife -= PlayerStatistic.Instance.AttackMelee;
    }
}
