using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Nerox_gd;

public class IA_Distance : IA
{
    [SerializeField] private GameObject projectil;
    [SerializeField] private float speedProjectil = 1f;

    protected override IEnumerator AttackPlayer()
    {
        GameObject proj = Instantiate(projectil, transform.position, Pratique.LookAt2D(projectil.transform.rotation, DirectionToPlayer), transform);
        proj.transform.DOMove(proj.transform.position + proj.transform.up * 50, speedProjectil)
        .SetSpeedBased(true)
        .SetEase(Ease.Linear)
        .OnComplete(() => Destroy(proj));
        yield return new WaitForSeconds(speedAttack);
        canAttack = true;
    }
}
