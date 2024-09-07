using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the functionality for the Options menu, including navigating back to the previous scene.
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the Main Menu scene when the Back button is clicked.
    /// </summary>
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
