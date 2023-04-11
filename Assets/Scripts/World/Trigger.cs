using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;
    [SerializeField] private float timeBeforeInvoke;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TimeInvoke());
            Destroy(gameObject, timeBeforeInvoke + 1);
        }

    }

    IEnumerator TimeInvoke()
    {
        yield return new WaitForSeconds(timeBeforeInvoke);
        unityEvent.Invoke();
    }
}
