using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string newText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("PriestPNJ").GetComponent<PNJ>().textPNJ = newText;
            GameObject.Find("TriggerDestroy").GetComponent<TriggerDestroy>().dropObject = true;
            Destroy(GameObject.Find("CaveWall"));
            Destroy(gameObject);
        }
    }
}
