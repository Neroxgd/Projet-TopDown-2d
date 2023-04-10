using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMusicA : MonoBehaviour
{
    [SerializeField] private AudioClip musicA;
    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.PlayMusic(musicA);
    }
}
