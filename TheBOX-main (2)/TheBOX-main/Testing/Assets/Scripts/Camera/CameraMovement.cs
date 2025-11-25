using UnityEngine;
using System.Collections; // Required for Coroutines

public class CameraKeyboardMover : MonoBehaviour
{
    // The distance the camera will move with each key press
    public float moveDistance = 20f;
    // The time in seconds the movement will take
    public float moveDuration = 0.5f; 

    private bool isMoving = false;

    void Update()
    {
        // Check if the right arrow key is pressed AND the camera is not already moving
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            StartCoroutine(MoveCameraRoutine(moveDistance, moveDuration));
        }
        // Check if the left arrow key is pressed AND the camera is not already moving
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            // Move by a negative distance to go left
            StartCoroutine(MoveCameraRoutine(-moveDistance, moveDuration));
        }
    }

    private IEnumerator MoveCameraRoutine(float distance, float duration)
    {
        isMoving = true; // Set flag to prevent multiple moves at once
        Vector3 startPosition = transform.position;
        // The target position is the current position plus the distance on the X axis
        Vector3 endPosition = startPosition + new Vector3(distance, 0, 0);
        float elapsedTime = 0;

        // Move every frame until the duration is reached
        while (elapsedTime < duration)
        {
            // IDK what this does
            float t = elapsedTime / duration;
            //Smoother movement
            t = Mathf.SmoothStep(0f, 1f, t); 

            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // Ensure the camera reaches the exact final position
        transform.position = endPosition;
        isMoving = false;
    }
}