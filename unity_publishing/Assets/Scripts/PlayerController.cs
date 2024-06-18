using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public int health = 5;
    private int score = 0;

    private Rigidbody rb;
    public Text scoreText;  // Reference to the ScoreText UI element
    public Text healthText; // Reference to the HealthText UI element
    public Text winLoseText; // Reference to the WinLoseText UI element
    public Image winLoseBG; // Reference to the WinLoseBG UI element

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText(); // Update the score text when the game starts
        UpdateHealthText(); // Update the health text when the game starts
        winLoseText.gameObject.SetActive(false); // Initially hide WinLoseText
        winLoseBG.gameObject.SetActive(false); // Initially hide WinLoseBG
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            UpdateScoreText(); // Update the score text when the player collects a coin
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            UpdateHealthText(); // Update the health text when the player hits a trap
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            WinGame(); // Handle the win condition
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            GameOver(); // Handle the game over condition
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    // Method to update the ScoreText UI element with the current score
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Method to update the HealthText UI element with the current health
    void UpdateHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Method to handle the win condition
    void WinGame()
    {
        winLoseText.text = "You Win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
        winLoseText.gameObject.SetActive(true); // Show WinLoseText
        winLoseBG.gameObject.SetActive(true); // Show WinLoseBG
        StartCoroutine(LoadScene(3)); // Wait 3 seconds before reloading the scene
    }

    // Method to handle the game over condition
    void GameOver()
    {
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        winLoseText.gameObject.SetActive(true); // Show WinLoseText
        winLoseBG.gameObject.SetActive(true); // Show WinLoseBG
        StartCoroutine(LoadScene(3)); // Wait 3 seconds before reloading the scene
    }

    // Coroutine to load the scene after a delay
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
