using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the logic for the Main Menu, including level selection, options, and exiting the game.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the level based on the provided level number.
    /// </summary>
    /// <param name="level">The build index of the level to load.</param>
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level + 1);
    }

    /// <summary>
    /// Loads the Options scene.
    /// </summary>
    public void Options()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Exits the game. If in the Unity Editor, stops play mode; if in a build, exits the application.
    /// </summary>
    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

}
