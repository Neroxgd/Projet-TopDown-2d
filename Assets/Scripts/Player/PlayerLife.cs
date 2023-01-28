using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class PlayerLife : MonoBehaviour
{
    // [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Image life;
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private Camera cam;
    [SerializeField] private float shakeForce = 0.1f;
    private float OrigineFillAmout = 1;

    public void TakeDamage(float dmg)
    {
        // cam.DOShakePosition(0.2f, 1, 50, 90, true, ShakeRandomnessMode.Harmonic);
        impulseSource.GenerateImpulseWithForce(shakeForce);
        life.DOFillAmount(OrigineFillAmout - dmg / 100, 1);
        OrigineFillAmout -= dmg / 100;
        OrigineFillAmout = Mathf.Clamp(OrigineFillAmout, 0, 1);
        if (dmg > 0)
            AudioManager.Instance.PlayAudioClip("Hit_Hurt21", false);
    }
}
