using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime);
    }
}
