using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] protected AudioClip audioClip;
    protected abstract void OnTriggerEnter2D(Collider2D other);
}
