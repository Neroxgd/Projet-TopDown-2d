using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Image life;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private float shakeForce = 0.1f;
    void Start()
    {
        PlayerStatistic.Instance.Life = 100;
    }

    public void TakeDamage(int dmg)
    {
        impulseSource.GenerateImpulseWithForce(shakeForce);
        life.DOFillAmount((PlayerStatistic.Instance.Life - dmg) / 100, 1);
        PlayerStatistic.Instance.Life -= dmg;
        if (dmg >= 0)
            AudioManager.Instance.PlayAudioClip("Hit_Hurt21", false);
    }
}
