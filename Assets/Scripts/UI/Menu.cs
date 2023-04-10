using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, credits, tuto;
    [SerializeField] private AudioClip buttonSelect;

    public void Play()
    {
        SceneManager.LoadScene("World");
        AudioManager.Instance.PlayAudioSound(buttonSelect);
    }

    public void Quit()
    {
        AudioManager.Instance.PlayAudioSound(buttonSelect);
        Application.Quit();
    }

    public void Credits()
    {
        mainMenu.SetActive(!mainMenu.activeInHierarchy);
        credits.SetActive(!credits.activeInHierarchy);
        AudioManager.Instance.PlayAudioSound(buttonSelect);
    }

    public void Tuto()
    {
        mainMenu.SetActive(!mainMenu.activeInHierarchy);
        tuto.SetActive(!tuto.activeInHierarchy);
        AudioManager.Instance.PlayAudioSound(buttonSelect);
    }
}
