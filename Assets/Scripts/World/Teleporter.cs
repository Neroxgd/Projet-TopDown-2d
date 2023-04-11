using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform pointToTeleporte, blackScreen;
    [SerializeField] private Light2D light2D;
    [SerializeField] private float intensityGlobalLight = 1;
    [SerializeField] private Vector3 AddAxeSpawn;
    [SerializeField] private float timeTransition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !PlayerMovement.pausePlayer)
        {
            blackScreen.DOScale(Vector3.one, timeTransition)
            .OnComplete(() =>
            {
                other.transform.position = pointToTeleporte.position + AddAxeSpawn;
                light2D.intensity = intensityGlobalLight;
                blackScreen.DOScale(Vector3.one * 140, timeTransition).SetDelay(1f);
            });
        }
    }
}
