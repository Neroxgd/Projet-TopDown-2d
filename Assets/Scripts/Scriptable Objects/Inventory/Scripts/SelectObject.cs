using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour
{
    private GetReferenceForButton RefButton;
    private Button button;
    void Start()
    {
        RefButton = transform.parent.parent.GetComponent<GetReferenceForButton>();
    }

    public void InitializeIndex()
    {
        for (int i = 0; i < RefButton.inventory.Container.Count; i++)
        {
            if (transform.parent.parent.GetChild(i) == transform.parent)
            {
                RefButton.IndexButton = i;
                break;
            }
        }
    }
}
