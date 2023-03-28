using UnityEngine;
using DG.Tweening;

public class Ammo : MonoBehaviour
{
    private Rigidbody2D rbAmmo;
    void Start()
    {
        Physics2D.IgnoreCollision(transform.GetComponentInChildren<Collider2D>(), GetComponentInParent<Collider2D>());
        rbAmmo = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DOTween.Kill(rbAmmo);
        if (other.CompareTag("Entity"))
            other.GetComponent<IA>().IALife -= PlayerStatistic.Instance.AttackDistance;
        else if (other.CompareTag("PNJ"))
        {
            rbAmmo.bodyType = RigidbodyType2D.Dynamic;
            rbAmmo.gravityScale = 0;
            rbAmmo.AddForce(-transform.up * 15, ForceMode2D.Impulse);
            rbAmmo.AddTorque(15, ForceMode2D.Impulse);
            // transform.parent = other.transform;
            Destroy(gameObject, 10);
            return;
        }
        transform.parent = other.transform;
        Destroy(rbAmmo);
        Destroy(GetComponentInChildren<Collider2D>());
        Destroy(gameObject, 30);
    }
}
