using UnityEngine;
using Nerox_gd;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Pratique.LookAtMouse2D(transform);
    }

    public void SetLightPlayer(float intensity, float distance, Vector2 angleLight)
    {
        GetComponent<Light2D>().intensity = intensity;
        GetComponent<Light2D>().pointLightOuterRadius = distance;
        GetComponent<Light2D>().pointLightInnerAngle = angleLight.x;
        GetComponent<Light2D>().pointLightOuterAngle = angleLight.y;
    }
}