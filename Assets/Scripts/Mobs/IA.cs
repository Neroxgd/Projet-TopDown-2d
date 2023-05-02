using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class IA : MonoBehaviour
{
    protected State state;
    private float iaCurrentLife;
    public float iaLife = 100;
    public float speedMove = 1f;
    public float detectPlayerRange = 3f;
    public float attackPlayerRange = 1f;
    public float attackDamage = 15f;
    public float speedAttack = 2f;
    protected bool canAttack;
    private float DistanceBetweenIAandPlayer { get { return Vector3.Distance(transform.position, PlayerStatistic.Instance.transform.position); } }
    protected Vector3 DirectionToPlayer { get { return PlayerStatistic.Instance.transform.position - transform.position; } }
    public LayerMask layerMaskDetectedToNotEnterInCollison /*V player and entity*/, layerMask/*V player*/;
    private Vector3 directionRoaming;
    public static bool isChasingPlayer;
    public AudioClip musicFight;
    public AudioClip targetSound;
    public GameObject[] objectsMobDrop;
    private SpriteRenderer spriteRenderer;
    private static bool isSoundPlaying;

    private Image lifeBarre;
    protected enum State
    {
        Roaming,
        ChasePlayer,
        AttackPlayer,
    }

    public float IALife
    {
        get { return iaCurrentLife; }
        set
        {
            lifeBarre.DOFillAmount(value / iaLife, 0.5f);
            iaCurrentLife = value;
            if (iaCurrentLife < 1)
            {
                DropObjects();
                if (!isChasingPlayer)
                    AudioManager.Instance.PlayCashMusic();
                AudioManager.Instance.PlayAudioSound(targetSound);
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        state = State.Roaming;
        iaCurrentLife = iaLife;
        lifeBarre = GetComponentsInChildren<Image>()[1];
        canAttack = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (DistanceBetweenIAandPlayer > 13) return;
        isChasingPlayer = false;
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
                        if (!isSoundPlaying)
                        {
                            AudioManager.Instance.PlayMusic(musicFight, false);
                            AudioManager.Instance.PlayAudioSound(targetSound);
                            StartCoroutine(TimeSound());
                        }
                        DOTween.Kill(transform);
                    }
                break;
            case State.ChasePlayer:
                if (DistanceBetweenIAandPlayer > detectPlayerRange * 2 || Physics2D.CircleCast(transform.position, 0.2f, DirectionToPlayer, 0.3f, layerMaskDetectedToNotEnterInCollison))
                {
                    state = State.Roaming;
                    AudioManager.Instance.PlayCashMusic();
                    break;
                }
                if (DistanceBetweenIAandPlayer < attackPlayerRange)
                {
                    state = State.AttackPlayer;
                    break;
                }
                ChasePlayer();
                break;
            case State.AttackPlayer:
                isChasingPlayer = true;
                if (DistanceBetweenIAandPlayer > attackPlayerRange)
                {
                    state = State.ChasePlayer;
                    break;
                }
                if (Physics2D.CircleCast(transform.position, 0.2f, DirectionToPlayer, 0.3f, layerMaskDetectedToNotEnterInCollison))
                {
                    state = State.Roaming;
                    break;
                }
                if (canAttack)
                {
                    canAttack = false;
                    StartCoroutine(AttackPlayer());
                }

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
        spriteRenderer.flipX = PlayerStatistic.Instance.transform.position.x < transform.position.x ? true : false;
        isChasingPlayer = true;
    }

    protected abstract IEnumerator AttackPlayer();

    private Vector3 GetRandomDirection()
    {
        directionRoaming = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        spriteRenderer.flipX = directionRoaming.x < 0 ? true : false;
        return transform.position + directionRoaming * Random.Range(2, 8);
    }

    private void DropObjects()
    {
        for (int i = 0; i < objectsMobDrop.Length; i++)
        {
            var dir = Random.insideUnitCircle.normalized / 2;
            GameObject currentObj = Instantiate(objectsMobDrop[i], transform.position, Quaternion.identity, transform.parent);
            currentObj.GetComponent<Collider2D>().enabled = !currentObj.GetComponent<Collider2D>().enabled;
            currentObj.transform.DOBlendableMoveBy(dir, 0.5f)
            .OnComplete(() => currentObj.GetComponent<Collider2D>().enabled = !currentObj.GetComponent<Collider2D>().enabled);
        }
    }

    IEnumerator TimeSound()
    {
        isSoundPlaying = true;
        yield return new WaitForSeconds(2);
        isSoundPlaying = false;
    }
}