using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BatMovement : MonoBehaviour
{
    [SerializeField] private Transform[] PointDeplacements;
    private int indexDeplacement = 0;
    [SerializeField] private float speedBat = 1;
    [SerializeField] private PlayerLife _playerLife;
    [SerializeField] private int batDamage = 10;
    [SerializeField] private Ease ease = Ease.InOutCubic;
    void Start()
    {
        transform.position = PointDeplacements[0].position;
        Fly();
    }

    private void Fly()
    {
        indexDeplacement++;
        transform.DOMove(PointDeplacements[indexDeplacement].position, speedBat)
        .SetEase(ease)
        .OnComplete(Fly)
        .SetSpeedBased(true)
        .SetDelay(Random.Range(3, 10));
        if (indexDeplacement == PointDeplacements.Length) indexDeplacement = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
            _playerLife.TakeDamage(batDamage);
    }
}
