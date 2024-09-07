using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    private float AngleRotation = 45f;

    private Vector3 DistanceApart = Vector3.zero;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Add a public bool to control Y-axis inversion
    public bool isInverted = false;

    private void Awake()
    {
        DistanceApart = transform.position - Player.position;

        // Load the saved inverted setting from PlayerPrefs
        if (PlayerPrefs.HasKey("isInverted"))
        {
            isInverted = PlayerPrefs.GetInt("isInverted") == 1;
        }
        else
        {
            isInverted = false;  // Default to normal Y-axis
        }
    }

    private void Update()
    {
        FollowPlayer();
        RotateAroundPlayer();
    }

    void RotateAroundPlayer()
    {
        // Rotate X (horizontal) stays the same
        rotationX += Input.GetAxis("Mouse X") * AngleRotation * Time.deltaTime;

        // For Y (vertical) rotation, apply inversion based on the isInverted boolean
        if (isInverted)
        {
            // Inverted: Moving mouse up makes camera move down
            rotationY += Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }
        else
        {
            // Normal: Moving mouse up makes camera move up
            rotationY -= Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }

        // Apply the rotation
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.rotation = rotation;

        // Keep the camera at a fixed distance from the player
        transform.position = Player.position - (rotation * new Vector3(0, 0, 5));

        // Always look at the player
        transform.LookAt(Player);
    }

    void FollowPlayer()
    {
        transform.position = Player.transform.position + DistanceApart;
    }
}
