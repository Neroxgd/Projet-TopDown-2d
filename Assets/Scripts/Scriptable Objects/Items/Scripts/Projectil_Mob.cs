using UnityEngine;
using DG.Tweening;

public class Projectil_Mob : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreCollision(transform.GetComponentInChildren<Collider2D>(), GetComponentInParent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("efzef");
        DOTween.Kill(transform);
        if (other.CompareTag("Player"))
            PlayerStatistic.Instance.transform.GetComponent<PlayerLife>().TakeDamage(GetComponentInParent<IA>().attackDamage);
        Destroy(gameObject);
    }
}
