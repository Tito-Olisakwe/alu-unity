using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioSource.Stop();
        }
        else if (GameObject.Find("WinFlag") && IsPlayerTouchingWinFlag())
        {
            audioSource.Stop();
        }
    }

    bool IsPlayerTouchingWinFlag()
    {
        return false;
    }
}
