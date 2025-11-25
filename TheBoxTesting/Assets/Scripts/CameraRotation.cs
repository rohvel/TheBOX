using UnityEngine;

// Add this using statement to work with UI elements if needed in the future
// using UnityEngine.UI; 

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed of the rotation transition
    private Quaternion targetRotation;
    private bool isRotating = false; // Optional: A flag to check if a rotation is in progress

    void Start()
    {
        targetRotation = transform.rotation; // Initialize target rotation to current rotation
    }

    void Update()
    {
        // Smoothly interpolate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetRotation *= Quaternion.Euler(0, -90, 0); // Rotate 90 degrees left around Y-axis
            }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetRotation *= Quaternion.Euler(0, 90, 0); // Rotate 90 degrees right around Y-axis
            }
    }

   
    // Public function to be called by the Left button's OnClick event
    public void RotateLeft()
    {
        // Add safety checks if needed (e.g., if you only want rotation when not already rotating)
        targetRotation *= Quaternion.Euler(0, -90, 0); // Rotate 90 degrees left around Y-axis
    }

    // Public function to be called by the Right button's OnClick event
    public void RotateRight()
    {
        // Add safety checks if needed
        targetRotation *= Quaternion.Euler(0, 90, 0); // Rotate 90 degrees right around Y-axis
    }
}
