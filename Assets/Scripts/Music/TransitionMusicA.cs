using UnityEngine;

public class TransitionMusicA : MonoBehaviour
{
    [SerializeField] private AudioClip musicA;
    void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.PlayMusic(musicA);
    }
}
