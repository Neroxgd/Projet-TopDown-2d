using UnityEngine;

public class TransitionMusicB : MonoBehaviour
{
    [SerializeField] private AudioClip musicB;
    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.PlayMusic(musicB);
    }
}
