using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject confirmation;
    [SerializeField] private AudioClip buttonSelect;

    public void GoMenu()
    {
        AudioManager.Instance.PlayAudioSound(buttonSelect);
        SceneManager.LoadScene("Menu");
    }

    // public void Confirmation()
    // {
    //     confirmation.SetActive(!confirmation.activeInHierarchy);
    //     AudioManager.Instance.PlayAudioSound(buttonSelect);
    // }
}
