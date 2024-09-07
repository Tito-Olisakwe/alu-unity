using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles pausing and resuming the game and interacting with the timer.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Pauses the game, activates the pause menu, and pauses the timer.
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        if (timer != null)
        {
            timer.PauseTimer();
        }
    }

    /// <summary>
    /// Resumes the game, hides the pause menu, and resumes the timer.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        if (timer != null)
        {
            timer.StartTimer();
        }
    }

    /// <summary>
    /// Restarts the current level by reloading the scene.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// <summary>
    /// Loads the Main Menu scene.
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the Options scene.
    /// </summary>
    public void Options()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        SceneManager.LoadScene("Options");
    }
}
