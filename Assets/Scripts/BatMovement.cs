using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BatMovement : MonoBehaviour
{
    [SerializeField] private Transform[] PointDeplacements;
    private int indexDeplacement = 0;
    [SerializeField] private float speedBat = 1;
    void Start()
    {
        Fly();
    }

    private void Fly()
    {
        indexDeplacement++;
        transform.DOMove(PointDeplacements[indexDeplacement].position, speedBat)
        .SetEase(Ease.InOutCubic)
        .OnComplete(Fly)
        .SetSpeedBased(true)
        .SetDelay(Random.Range(3, 10));
        if (indexDeplacement == PointDeplacements.Length) indexDeplacement = 0;
    }
}
