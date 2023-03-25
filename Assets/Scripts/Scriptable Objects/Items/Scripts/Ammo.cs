using UnityEngine;
using DG.Tweening;

public class Ammo : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreCollision(transform.GetComponentInChildren<Collider2D>(), GetComponentInParent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DOTween.Kill(transform);
        if (other.CompareTag("Entity"))
            other.GetComponent<IA>().IALife -= PlayerStatistic.Instance.Attack;
        transform.parent = other.transform;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponentInChildren<Collider2D>());
        Destroy(gameObject, 30);
    }
}
