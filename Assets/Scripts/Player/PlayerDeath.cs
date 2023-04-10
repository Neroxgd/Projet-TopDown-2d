using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform blackScreen;
    [SerializeField] private float timeTransition;
    [SerializeField] private Light2D light2D;

    public void Death()
    {
        blackScreen.DOScale(Vector3.one, timeTransition)
        .OnComplete(() =>
        {
            light2D.intensity = 1;
            transform.position = Checkpoint.currentcheckpoint;
            blackScreen.DOScale(Vector3.one * 140, timeTransition).SetDelay(1f);
        });
    }
}