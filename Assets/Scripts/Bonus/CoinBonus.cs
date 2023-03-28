using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonus : Bonus
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudioSound(audioClip);
            Destroy(gameObject);
        }
    }
}
