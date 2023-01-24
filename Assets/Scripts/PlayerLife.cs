using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Image life;
    [SerializeField] private Camera cam;
    private float OrigineFillAmout = 1;
    public void TakeDamage(float dmg)
    {
        cam.DOShakePosition(0.2f, 1, 50, 90, true, ShakeRandomnessMode.Harmonic);
        life.DOFillAmount(OrigineFillAmout - dmg / 100, 1);
        OrigineFillAmout -= dmg / 100;
    }
}
