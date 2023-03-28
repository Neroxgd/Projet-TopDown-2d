using UnityEngine;

public class EnterInHouse : MonoBehaviour
{
    [SerializeField] private GameObject blackScreenHouse;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            blackScreenHouse.SetActive(false);
    }
}
