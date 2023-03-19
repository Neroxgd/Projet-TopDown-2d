using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public /*abstract*/ class IA : MonoBehaviour
{
    protected State state;
    public float speedMove = 1f;
    public float detectPlayerRange = 3f;
    public LayerMask layerMaskDetected;
    private Vector3 direction;
    protected enum State
    {
        Roaming,
        ChasePlayer,
        AttackPlayer,
        // ReturnToStart
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
                if (Physics2D.OverlapCircle(transform.position + direction / 2, 0.5f, layerMaskDetected))
                    DOTween.Kill(transform);
                if (Vector3.Distance(transform.position, PlayerStatistic.Instance.transform.position) < detectPlayerRange)
                {
                    Ray ray = new Ray(transform.position, PlayerStatistic.Instance.transform.position - transform.position);
                    if (Physics2D.GetRayIntersection(ray, Vector3.Distance(transform.position, PlayerStatistic.Instance.transform.position), layerMaskDetected).collider.CompareTag("Player"))
                        //erreur de référence, regarder comment utiliser getRayIntersection
                        state = State.ChasePlayer;
                }

                break;
            case State.ChasePlayer:
                print("jaaa");
                break;
            case State.AttackPlayer:
                break;
                // case State.ReturnToStart:
                //     break;
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

    }

    private Vector3 GetRandomDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return transform.position + direction * Random.Range(2, 8);
    }
}
