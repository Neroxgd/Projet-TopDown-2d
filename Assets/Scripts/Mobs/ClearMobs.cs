using UnityEngine.Events;
using UnityEngine;

public class ClearMobs : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;

    void OnDestroy()
    {
        unityEvent.Invoke();
    }
}
