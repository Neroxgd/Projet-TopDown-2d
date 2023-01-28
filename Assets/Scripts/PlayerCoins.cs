using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        AudioManager.Instance.PlayAudioClip("Pickup_Coin4", false);
        Destroy(gameObject);
    }
}
