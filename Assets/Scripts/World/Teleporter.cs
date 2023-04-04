using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform pointToTeleporte;
    [SerializeField] private Light2D light2D;
    [SerializeField] private float intensityGlobalLight = 1;
    [SerializeField] private bool YAxeSpawn;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = pointToTeleporte.position + (YAxeSpawn ? transform.up : -transform.up);
            light2D.intensity = intensityGlobalLight;
        }

    }
}
