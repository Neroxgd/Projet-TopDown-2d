using UnityEngine;

public class AmmoBonus : Bonus
{
    [SerializeField] private int ammoCountBonus;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerAttack>().AmmoCount += ammoCountBonus;
            AudioManager.Instance.PlayAudioSound(audioClip);
            Destroy(gameObject);
        }
    }
}