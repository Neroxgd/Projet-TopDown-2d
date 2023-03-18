using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public /*abstract*/ class IA : MonoBehaviour
{
    protected State state;
    public float SpeedMove = 1f;
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
                break;
            case State.ChasePlayer:
                break;
            case State.AttackPlayer:
                break;
            // case State.ReturnToStart:
            //     break;
        }
        // RaycastHit hit;
        if (Physics2D.OverlapCircle(transform.position + direction / 2, 0.5f, layerMaskDetected))
            DOTween.Kill(transform);
    }

    private void Roaming()
    {
        if (DOTween.IsTweening(transform)) return;
        transform.DOMove(GetRandomDirection(), SpeedMove).SetSpeedBased(true).SetEase(Ease.Linear);
    }

    private Vector3 GetRandomDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return transform.position + direction * Random.Range(2, 8);
    }
}
