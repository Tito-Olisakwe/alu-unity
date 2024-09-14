using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;  // Reference to the player's transform
    private float AngleRotation = 45f;  // Speed of camera rotation

    private Vector3 Offset;  // Offset between the camera and the player

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public bool isInverted = false;

    private void Awake()
    {
        // Calculate and store the offset distance between the camera and player
        Offset = transform.position - Player.position;

        // Get the inversion setting from PlayerPrefs
        if (PlayerPrefs.HasKey("isInverted"))
        {
            isInverted = PlayerPrefs.GetInt("isInverted") == 1;
        }
        else
        {
            isInverted = false;
        }
    }

    private void LateUpdate()
    {
        // Rotate the camera around the player
        RotateAroundPlayer();
    }

    // Rotates the camera around the player based on mouse input
    void RotateAroundPlayer()
    {
        // Horizontal rotation using Mouse X
        rotationX += Input.GetAxis("Mouse X") * AngleRotation * Time.deltaTime;

        // Vertical rotation using Mouse Y (inverted if necessary)
        if (isInverted)
        {
            rotationY += Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }
        else
        {
            rotationY -= Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }

        // Clamp vertical rotation to prevent the camera from flipping
        rotationY = Mathf.Clamp(rotationY, -30f, 60f);

        // Create a rotation quaternion based on the mouse input
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Apply the rotation while maintaining the offset distance from the player
        transform.position = Player.position + rotation * Offset;

        // Make the camera look at the player
        transform.LookAt(Player);
    }
}
