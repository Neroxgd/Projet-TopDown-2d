using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobweb : MonoBehaviour
{
    [SerializeField] private float timeDestroyCobweb, speedPlayerInCobweb;

    void Start()
    {
        StartCoroutine(DestroyCobweb());
        IEnumerator DestroyCobweb()
        {
            yield return new WaitForSeconds(timeDestroyCobweb);
            if (Physics2D.OverlapCircle(transform.position, GetComponent<CircleCollider2D>().radius).CompareTag("Player"))
                PlayerStatistic.Instance.MoveSpeed = PlayerStatistic.Instance.GetComponent<PlayerMovement>().SpeedPlayer;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            PlayerStatistic.Instance.MoveSpeed = speedPlayerInCobweb;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            PlayerStatistic.Instance.MoveSpeed = PlayerStatistic.Instance.GetComponent<PlayerMovement>().SpeedPlayer;
    }
}