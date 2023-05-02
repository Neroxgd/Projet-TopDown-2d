using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{

    // [SerializeField] private GameObject confirmation;
    [SerializeField] private AudioClip buttonSelect, menuAudio;
    // [SerializeField] private GameObject inventory;

    public void GoMenu()
    {
        AudioManager.Instance.PlayAudioSound(buttonSelect);
        AudioManager.Instance.PlayMusic(menuAudio);
        // inventory.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    // public void Confirmation()
    // {
    //     confirmation.SetActive(!confirmation.activeInHierarchy);
    //     AudioManager.Instance.PlayAudioSound(buttonSelect);
    // }
}
