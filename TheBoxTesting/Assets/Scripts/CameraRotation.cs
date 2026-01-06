using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed of the rotation transition
    public Level4GameManager gameManagerLevel4;
    private Quaternion targetRotation;
    private bool canDo = true;

    void Start()
    {
        targetRotation = transform.rotation; // Initialize target rotation to current rotation
    }

    void Update()
    {
        canDo = true;
        if (gameManagerLevel4 != null)
        {
            if (gameManagerLevel4.UIEnabled == true)
            {
                canDo = false;
            }
        }
        // Check for Left Arrow key press
        if (canDo == true) {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                RotateLeft();
            }
            // Check for Right Arrow key press
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RotateRight();
            }

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Public method to rotate the camera left
    public void RotateLeft()
    {
        targetRotation *= Quaternion.Euler(0, -90, 0); // Rotate 90 degrees left around Y-axis
    }

    // Public method to rotate the camera right
    public void RotateRight()
    {
        targetRotation *= Quaternion.Euler(0, 90, 0); // Rotate 90 degrees right around Y-axis
    }
}