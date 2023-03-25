using UnityEngine;

public class Utils
{
    public static Quaternion LookAt2D(Quaternion rotation, Vector3 target)
    {
        Vector3 diff = target;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        return rotation;
    }
}
