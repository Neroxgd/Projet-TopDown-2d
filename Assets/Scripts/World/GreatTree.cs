using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GreatTree : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!DOTween.IsTweening(transform) && other.CompareTag("Player") && !other.GetComponentInParent<PlayerAttack>().CanAttack)
            transform.DOShakePosition(0.2f, new Vector3(0.2f, 0, 0), 50);
    }
}
