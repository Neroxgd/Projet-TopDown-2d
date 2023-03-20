using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class IA : MonoBehaviour
{
    protected State state;
    public float speedMove = 1f;
    public float detectPlayerRange = 3f;
    public float attackPlayerRange = 1f;
    public float attackDamage = 15f;
    public float speedAttack = 2f;
    private bool canAttack;
    private float DistanceBetweenIAandPlayer { get { return Vector3.Distance(transform.position, PlayerStatistic.Instance.transform.position); } }
    private Vector3 DirectionToPlayer { get { return PlayerStatistic.Instance.transform.position - transform.position; } }
    public LayerMask layerMaskDetectedToNotEnterInCollison, layerMask;
    private Vector3 directionRoaming;
    protected enum State
    {
        Roaming,
        ChasePlayer,
        AttackPlayer,
    }

    void Start()
    {
        state = State.Roaming;
    }

    void Update()
    {
        StateManager();
    }

    private void StateManager()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                Roaming();
                if (Physics2D.OverlapCircle(transform.position + directionRoaming / 2, 0.5f, layerMaskDetectedToNotEnterInCollison))
                    DOTween.Kill(transform);
                if (DistanceBetweenIAandPlayer < detectPlayerRange)
                    if (Physics2D.Raycast(transform.position, DirectionToPlayer, Vector3.Distance(transform.position, PlayerStatistic.Instance.transform.position), layerMask).transform.CompareTag("Player"))
                    {
                        state = State.ChasePlayer;
                        DOTween.Kill(transform);
                    }
                break;
            case State.ChasePlayer:
                if (DistanceBetweenIAandPlayer > detectPlayerRange * 2 || Physics2D.CircleCast(transform.position, 0.2f, DirectionToPlayer, 0.3f, layerMaskDetectedToNotEnterInCollison))
                {
                    state = State.Roaming;
                    break;
                }
                if (DistanceBetweenIAandPlayer < attackPlayerRange)
                {
                    state = State.AttackPlayer;
                    canAttack = true;
                    break;
                }
                ChasePlayer();
                break;
            case State.AttackPlayer:
                if (DistanceBetweenIAandPlayer > attackPlayerRange)
                {
                    state = State.ChasePlayer;
                    break;
                }
                if (canAttack)
                    StartCoroutine(AttackPlayer());
                break;
        }
    }

    private void Roaming()
    {
        if (DOTween.IsTweening(transform)) return;
        transform.DOMove(GetRandomDirection(), speedMove)
        .SetSpeedBased(true)
        .SetEase(Ease.Linear)
        .SetDelay(Random.Range(2, 10));
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerStatistic.Instance.transform.position, speedMove * 2 * Time.deltaTime);
    }

    protected abstract IEnumerator AttackPlayer();

    // IEnumerator AttackPlayer()
    // {
    //     canAttack = false;
    //     PlayerStatistic.Instance.transform.GetComponent<PlayerLife>().TakeDamage(attackDamage);
    //     yield return new WaitForSeconds(speedAttack);
    //     canAttack = true;
    // }

    private Vector3 GetRandomDirection()
    {
        directionRoaming = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return transform.position + directionRoaming * Random.Range(2, 8);
    }
}