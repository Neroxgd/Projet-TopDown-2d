using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private float healtGiven;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
            other.GetComponent<PlayerLife>().TakeDamage(-healtGiven);
        }
    }
    public void PickUp()
    {
        AudioManager.Instance.PlayAudioClip("Powerup44", false);
        Destroy(gameObject);
    }
}
