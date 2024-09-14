using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    private float AngleRotation = 45f;

    private Vector3 DistanceApart = Vector3.zero;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public bool isInverted = false;

    private void Awake()
    {
        DistanceApart = transform.position - Player.position;

        if (PlayerPrefs.HasKey("isInverted"))
        {
            isInverted = PlayerPrefs.GetInt("isInverted") == 1;
        }
        else
        {
            isInverted = false;
        }
    }

    private void Update()
    {
        FollowPlayer();
        RotateAroundPlayer();
    }

    void RotateAroundPlayer()
    {
        rotationX += Input.GetAxis("Mouse X") * AngleRotation * Time.deltaTime;

        if (isInverted)
        {
            rotationY += Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }
        else
        {
            rotationY -= Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.rotation = rotation;

        transform.position = Player.position - (rotation * new Vector3(0, 0, 5));

        transform.LookAt(Player);
    }

    void FollowPlayer()
    {
        transform.position = Player.transform.position + DistanceApart;
    }
}
