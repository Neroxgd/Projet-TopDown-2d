using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform blackScreen;
    [SerializeField] private float timeTransition;
    [SerializeField] private Light2D light2D;
    [SerializeField] private AudioClip death;

    public void Death()
    {
        AudioManager.Instance.PlayAudioSound(death);
        blackScreen.DOScale(Vector3.one, timeTransition)
        .OnComplete(() =>
        {
            light2D.intensity = 1;
            transform.position = Checkpoint.currentcheckpoint;
            blackScreen.DOScale(Vector3.one * 140, timeTransition).SetDelay(1f);
        });
    }
}