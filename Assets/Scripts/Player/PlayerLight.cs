using UnityEngine;
using Nerox_gd;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Pratique.LookAtMouse2D(transform);
    }

    public void SetLightPlayer(float intensity, float distance, float angleLight)
    {
        GetComponent<Light2D>().intensity = intensity;
        GetComponent<Light2D>().pointLightOuterRadius = distance;
        GetComponent<Light2D>().pointLightOuterAngle = angleLight;
    }
}