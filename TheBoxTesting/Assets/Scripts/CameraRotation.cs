using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed of the rotation transition
    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation; // Initialize target rotation to current rotation
    }

    void Update()
    {
        // Check for Left Arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetRotation *= Quaternion.Euler(0, -90, 0); // Rotate 90 degrees left around Y-axis
        }
        // Check for Right Arrow key press
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetRotation *= Quaternion.Euler(0, 90, 0); // Rotate 90 degrees right around Y-axis
        }

        // Smoothly interpolate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}