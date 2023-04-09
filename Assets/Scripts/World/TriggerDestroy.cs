using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDestroy;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            foreach (GameObject obj in objectsToDestroy)
                Destroy(obj);
    }
}
