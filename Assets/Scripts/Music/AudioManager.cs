using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip menuAudio;
    public AudioClip cashMusic { get; private set; }
    public AudioSource audioSource { get; private set; }
    public static AudioManager Instance { private set; get; }
    [SerializeField] private float timeFadeChangeMusic;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayMusic(menuAudio);
    }

    public void PlayMusic(AudioClip audioClip)
    {
        if (audioClip == null) return;
        if (audioSource.isPlaying && audioSource.clip == audioClip) return;
        audioSource.DOFade(0, timeFadeChangeMusic)
        .OnComplete(() =>
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            audioSource.DOFade(0.5f, timeFadeChangeMusic);
        });
        cashMusic = audioClip;
    }

    public void PlayMusic(AudioClip audioClip, bool musicCash)
    {
        if (audioClip == null) return;
        if (audioSource.isPlaying && audioSource.clip == audioClip) return;
        audioSource.DOFade(0, timeFadeChangeMusic)
        .OnComplete(() =>
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            audioSource.DOFade(0.5f, timeFadeChangeMusic);
        });
        if (musicCash)
            cashMusic = audioClip;
    }

    public void PlayCashMusic()
    {
        if (cashMusic == null) return;
        if (audioSource.isPlaying && audioSource.clip == cashMusic) return;
        audioSource.DOFade(0, timeFadeChangeMusic)
        .OnComplete(() =>
        {
            audioSource.clip = cashMusic;
            audioSource.Play();
            audioSource.DOFade(0.5f, timeFadeChangeMusic);
        });
    }

    public void PlayAudioSound(AudioClip audioClip)
    {
        if (audioClip == null) return;
        // if (audioSource == null)
        //     audioSource = GetComponent<AudioSource>();
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
