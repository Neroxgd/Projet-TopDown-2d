using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform blackScreen;
    [SerializeField] private float timeTransition;

    public void Death()
    {
        blackScreen.DOScale(Vector3.one, timeTransition)
        .OnComplete(() =>
        {
            transform.position = Checkpoint.currentcheckpoint;
            blackScreen.DOScale(Vector3.one * 140, timeTransition).SetDelay(1f);
        });
    }
}