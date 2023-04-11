using UnityEngine;
using DG.Tweening;

public class Jar : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsInJar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ammo"))
            ExploseJar();
        else if (other.CompareTag("Player") && !other.GetComponentInParent<PlayerAttack>().CanAttack)
            ExploseJar();
    }

    private void ExploseJar()
    {
        for (int i = 0; i < objectsInJar.Length; i++)
        {
            var dir = Random.insideUnitCircle.normalized / 2;
            GameObject currentObj = Instantiate(objectsInJar[i], transform.position, Quaternion.identity, transform.parent);
            currentObj.GetComponent<Collider2D>().enabled = false;
            currentObj.transform.DOBlendableMoveBy(dir, 0.5f)
            .OnComplete(() => currentObj.GetComponent<Collider2D>().enabled = true);
        }
        Destroy(gameObject);
    }
}