using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    public static AudioManager Instance { private set; get; }
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic(audioClips[0]);
    }

    public void PlayMusic(AudioClip audioClip)
    {
        if (audioClip == null) return;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayAudioSound(AudioClip audioClip)
    {
        if (audioClip == null) return;
        audioSource.PlayOneShot(audioClip);
        // AudioClip audioClip = null;
        // foreach (AudioClip clip in audioClips)
        // {
        //     if (clip.name == name)
        //     {
        //         audioClip = clip;
        //         break;
        //     }
        // }

        // if (audioClip == null)
        // {
        //     print("audio clip not found : " + name);
        //     return;
        // }

        // if (ifLoop)
        // {
        //     audioSource.clip = audioClip;
        //     audioSource.loop = true;
        //     audioSource.Play();
        //     return;
        // }

        // audioSource.PlayOneShot(audioClip);
    }
}
