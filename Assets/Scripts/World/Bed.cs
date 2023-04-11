using UnityEngine;

public class Bed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerLife>().TakeDamage(-100);
    }
}
