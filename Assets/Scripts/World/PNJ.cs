using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PNJ : MonoBehaviour
{
    [TextArea(5, 20)] public string textPNJ;
    private BullPNJ _bullPNJ;
    void Start()
    {
        _bullPNJ = FindObjectOfType<BullPNJ>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _bullPNJ.ShowBull(textPNJ);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _bullPNJ.HideBull();
    }
}

