using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    public static AudioManager Instance { private set; get; }
    void Awake()
    {
        // if (Instance = null)
        Instance = this;
        // else
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayAudioClip("Phobia", true);
    }

    public void PlayAudioClip(string name, bool ifLoop)
    {
        AudioClip audioClip = null;
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == name)
            {
                audioClip = clip;
                break;
            }
        }

        if (audioClip == null)
        {
            print("audio clip not found : " + name);
            return;
        }

        if (ifLoop)
        {
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
            return;
        }

        audioSource.PlayOneShot(audioClip);
    }
}
