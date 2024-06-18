using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    private Color originalTrapColor = new Color32(255, 0, 0, 255);
    private Color originalGoalColor = new Color32(0, 128, 0, 255);
    private Color colorblindTrapColor = new Color32(255, 112, 0, 255);
    private Color colorblindGoalColor = Color.blue;

    private void Start()
    {
        // Store the original colors of the materials
        if (trapMat != null) originalTrapColor = trapMat.color;
        if (goalMat != null) originalGoalColor = goalMat.color;

        // Add listener for the toggle
        if (colorblindMode != null)
        {
            colorblindMode.onValueChanged.AddListener(delegate {
                ToggleValueChanged(colorblindMode.isOn);
            });

            // Set the initial color based on the toggle state
            ToggleValueChanged(colorblindMode.isOn);
        }

        // Debug messages to confirm the script is running and variables are assigned
        if (trapMat == null) Debug.LogError("Trap material is not assigned.");
        if (goalMat == null) Debug.LogError("Goal material is not assigned.");
        if (colorblindMode == null) Debug.LogError("Colorblind Mode toggle is not assigned.");
    }

    private void ToggleValueChanged(bool isColorblind)
    {
        if (isColorblind)
        {
            // Change to colorblind mode colors
            if (trapMat != null) trapMat.color = colorblindTrapColor;
            if (goalMat != null) goalMat.color = colorblindGoalColor;
        }
        else
        {
            // Change back to original colors
            if (trapMat != null) trapMat.color = originalTrapColor;
            if (goalMat != null) goalMat.color = originalGoalColor;
        }
    }

    public void PlayMaze()
    {
        Debug.Log("PlayMaze method called");

        // Check if colorblindMode is toggled on
        if (colorblindMode != null && colorblindMode.isOn)
        {
            Debug.Log("Colorblind mode is ON");
            // Change the trap material color
            if (trapMat != null)
            {
                Debug.Log("Changing trap material color");
                trapMat.color = colorblindTrapColor;
            }
            // Change the goal material color
            if (goalMat != null)
            {
                Debug.Log("Changing goal material color");
                goalMat.color = colorblindGoalColor;
            }
        }
        else
        {
            Debug.Log("Colorblind mode is OFF");
            // Reset the materials to their original colors
            if (trapMat != null)
            {
                Debug.Log("Resetting trap material color");
                trapMat.color = originalTrapColor;
            }
            if (goalMat != null)
            {
                Debug.Log("Resetting goal material color");
                goalMat.color = originalGoalColor;
            }
        }

        // Load the maze scene
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
