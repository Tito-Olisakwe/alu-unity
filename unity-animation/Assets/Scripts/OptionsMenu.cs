using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private bool isInverted;

    private void Start()
    {
        if (PlayerPrefs.HasKey("isInverted"))
        {
            isInverted = PlayerPrefs.GetInt("isInverted") == 1;
            invertYToggle.isOn = isInverted;
        }
        else
        {
            isInverted = false;
            invertYToggle.isOn = false;
        }
    }

    /// <summary>
    /// Apply the changes made in the options menu and return to the previous scene.
    /// </summary>
    public void Apply()
    {
        isInverted = invertYToggle.isOn;
        PlayerPrefs.SetInt("isInverted", isInverted ? 1 : 0);
        PlayerPrefs.Save();
        ReturnToPreviousScene();
    }

    /// <summary>
    /// Discard changes and return to the previous scene.
    /// </summary>
    public void Back()
    {
        ReturnToPreviousScene();
    }

    /// <summary>
    /// Helper method to load the previous scene.
    /// </summary>
    private void ReturnToPreviousScene()
    {
        Time.timeScale = 1f;
        string previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu"); 
        SceneManager.LoadScene(previousScene);
    }
}
