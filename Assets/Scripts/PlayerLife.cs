using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLife : MonoBehaviour
{
    // [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Image life;
    [SerializeField] private Camera cam;
    private float OrigineFillAmout = 1;
    public void TakeDamage(float dmg)
    {
        cam.DOShakePosition(0.2f, 1, 50, 90, true, ShakeRandomnessMode.Harmonic);
        life.DOFillAmount(OrigineFillAmout - dmg / 100, 1);
        OrigineFillAmout -= dmg / 100;
        AudioManager.Instance.PlayAudioClip("Hit_Hurt21", false);
    }
}
