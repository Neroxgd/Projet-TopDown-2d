using UnityEngine;
using DG.Tweening;

public class SpawnGoblins : MonoBehaviour
{
    [SerializeField] private AudioClip audioClipStart, audioClipEnd;
    [SerializeField] private Transform blackScreen;
    [SerializeField] private PNJ _bullPNJ;
    [SerializeField] private GameObject[] goblins;
    [SerializeField] private float timeTransition;
    [SerializeField] private GameObject youWin;
    private int compt;

    public void Spawn()
    {
        gameObject.SetActive(true);
        AudioManager.Instance.PlayMusic(audioClipStart);
        compt = goblins.Length;
    }

    public void CheckCountChild()
    {
        compt--;
        if (compt <= 0)
            EndEvent();
    }

    private void EndEvent()
    {
        AudioManager.Instance.PlayMusic(audioClipEnd);
        blackScreen.DOScale(Vector3.one, timeTransition).OnComplete(() => youWin.SetActive(true));
    }
}