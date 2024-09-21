using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalTimeText;

    private float startTime;
    private float elapsedTime;
    private bool timerStarted;
    private bool isPaused;
    private float timeWhenPaused;

    private void Start()
    {
        timerStarted = false;
        elapsedTime = 0f;
        isPaused = false;
    }

    private void Update()
    {
        if (timerStarted && !isPaused)
        {
            elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    public void StartTimer()
    {
        if (!timerStarted)
        {
            startTime = Time.time;
            timerStarted = true;
        }

        if (isPaused)
        {
            startTime = Time.time - timeWhenPaused;
            isPaused = false;
        }
    }

    /// <summary>
    /// Pauses the timer and stores the time when paused.
    /// </summary>
    public void PauseTimer()
    {
        if (timerStarted)
        {

            timeWhenPaused = elapsedTime;
            isPaused = true;
        }
    }

    /// <summary>
    /// Stops the timer completely.
    /// </summary>
    public void StopTimer()
    {
        timerStarted = false;
        isPaused = false;
    }

    /// <summary>
    /// Updates the timer text based on the elapsed time.
    /// </summary>
    public void UpdateTimerText(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    /// <summary>
    /// Display the final time on the WinCanvas.
    /// </summary>
    public void Win()
    {
        if (finalTimeText != null)
        {
            finalTimeText.text = timerText.text;
        }
    }
}
