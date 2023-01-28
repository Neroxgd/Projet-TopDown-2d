using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            PickUp();
            other.GetComponent<PlayerLife>().TakeDamage(-30);
        }
    }
    public void PickUp()
    {
        AudioManager.Instance.PlayAudioClip("Powerup44", false);
        Destroy(gameObject);
    }
}
