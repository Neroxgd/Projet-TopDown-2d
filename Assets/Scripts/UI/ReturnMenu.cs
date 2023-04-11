using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{

    // [SerializeField] private GameObject confirmation;
    [SerializeField] private AudioClip buttonSelect, menuAudio;

    public void GoMenu()
    {
        AudioManager.Instance.PlayAudioSound(buttonSelect);
        AudioManager.Instance.PlayMusic(menuAudio);
        SceneManager.LoadScene("Menu");
    }

    // public void Confirmation()
    // {
    //     confirmation.SetActive(!confirmation.activeInHierarchy);
    //     AudioManager.Instance.PlayAudioSound(buttonSelect);
    // }
}
