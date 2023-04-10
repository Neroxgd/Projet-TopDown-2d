using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Image life;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private float shakeForce = 0.1f;
    [SerializeField] private AudioClip musicNormalBiome;
    [SerializeField] private AudioClip audioClip;
    void Start()
    {
        PlayerStatistic.Instance.Life = 100;
        AudioManager.Instance.PlayMusic(musicNormalBiome);
    }

    public void TakeDamage(float dmg)
    {
        impulseSource.GenerateImpulseWithForce(shakeForce);
        if (dmg > 0)
            dmg = Mathf.Clamp(dmg - PlayerStatistic.Instance.TotalArmor, 1, Mathf.Infinity);
        life.DOFillAmount((PlayerStatistic.Instance.Life - dmg) / 100, 1);
        PlayerStatistic.Instance.Life -= dmg;
        if (dmg >= 0)
            AudioManager.Instance.PlayAudioSound(audioClip);
        if (PlayerStatistic.Instance.Life <= 1)
        {
            GetComponent<PlayerDeath>().Death();
            TakeDamage(-100);
        }
    }
}
