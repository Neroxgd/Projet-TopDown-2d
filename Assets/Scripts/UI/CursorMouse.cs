using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMouse : MonoBehaviour
{
    [SerializeField] private GameObject cursor;

    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        cursor.transform.position = Mouse.current.position.ReadValue();
    }
}
