using UnityEngine;

public class HeartBonus : Bonus
{
    [SerializeField] private float healtGiven;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatistic.Instance.transform.GetComponent<PlayerLife>().TakeDamage(-healtGiven);
            AudioManager.Instance.PlayAudioSound(audioClip);
            Destroy(gameObject);
        }
    }
}
