using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BullPNJ : MonoBehaviour
{
    [SerializeField] private Transform posToMove;
    [SerializeField] private float pauseBetweenLetter = 0.1f;
    private TextMeshProUGUI textToShow;
    [SerializeField] private Transform originePos;

    void Start()
    {
        textToShow = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ShowBull(string textPNJ)
    {
        textToShow.text = "";
        transform.DOMove(posToMove.position, 0.4f)
        .OnComplete(() => StartCoroutine(ShowText(textPNJ)));
    }

    public void HideBull()
    {
        StopAllCoroutines();
        transform.DOMove(originePos.position, 0.4f)
        .OnComplete(() => textToShow.text = "");
    }

    private IEnumerator ShowText(string textPNJ)
    {
        foreach (char letter in textPNJ.ToCharArray())
        {
            textToShow.text += letter;
            yield return new WaitForSeconds(pauseBetweenLetter);
        }
    }
}
