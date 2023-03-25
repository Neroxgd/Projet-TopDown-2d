using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Melee : IA
{
    protected override IEnumerator AttackPlayer()
    {
        PlayerStatistic.Instance.transform.GetComponent<PlayerLife>().TakeDamage(attackDamage);
        yield return new WaitForSeconds(speedAttack);
        canAttack = true;
    }
}
