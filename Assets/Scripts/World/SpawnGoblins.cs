using UnityEngine;


public class SpawnGoblins : MonoBehaviour
{
    [SerializeField] private AudioClip audioClipStart, audioClipEnd;
    [SerializeField] private PNJ _bullPNJ;
    [SerializeField, TextArea(5, 20)] private string newText;
    [SerializeField] private GameObject[] goblins;
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
        _bullPNJ.textPNJ = newText;
    }
}