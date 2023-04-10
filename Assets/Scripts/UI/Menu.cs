using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, credits;

    public void Play()
    {
        SceneManager.LoadScene("World");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        mainMenu.SetActive(!mainMenu.activeInHierarchy);
        credits.SetActive(!credits.activeInHierarchy);
    }
}
