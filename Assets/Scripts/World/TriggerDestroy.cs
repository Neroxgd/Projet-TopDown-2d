using UnityEngine;
using DG.Tweening;

public class TriggerDestroy : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDestroy, objectsToDrop;
    public bool dropObject { get; set; }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToDestroy)
                Destroy(obj);
            if (dropObject)
                foreach (GameObject obj in objectsToDrop)
                {
                    dropObject = false;
                    GameObject objectDroped = Instantiate(obj, transform.position, Quaternion.identity, transform);
                    objectDroped.GetComponent<Collider2D>().enabled = false;
                    objectDroped.transform.DOBlendableMoveBy(Vector3.down, 0.5f)
                    .OnComplete(() => objectDroped.GetComponent<Collider2D>().enabled = true);
                }
        }
    }
}
