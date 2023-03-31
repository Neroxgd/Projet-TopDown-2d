using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GreatTree : MonoBehaviour
{
    [SerializeField] private GameObject prefabWood;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!DOTween.IsTweening(transform) && other.CompareTag("Player") && !other.GetComponentInParent<PlayerAttack>().CanAttack)
        {
            transform.DOShakePosition(0.2f, new Vector3(0.2f, 0, 0), 50);
            GameObject currentWood = Instantiate(prefabWood, transform.position + new Vector3(Random.insideUnitCircle.normalized.x, -Mathf.Abs(Random.insideUnitCircle.normalized.y)) * 2, Quaternion.identity);
            //set parent after to keep the scale of the object
            currentWood.transform.SetParent(transform);
        }
    }
}
