using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    [Header("Zoom Settings")]
    public float targetFOV = 0.6f;
    public float zoomTime = 0.2f;
    public float zoomWaitTime = 0.5f;

    [Header("Vertical Movement")]
    public float moveAmount = 0.5f; // how high it moves
    public float moveTime = 0.3f;

    private float originalFOV;
    private Vector3 originalPos;

    private void Start()
    {
        cam = GetComponent<Camera>();
        originalFOV = cam.fieldOfView;
        originalPos = transform.position;
    }

    public IEnumerator ZoomFOVAndMoveUp()
    {
        Vector3 upPos = originalPos + new Vector3(0, moveAmount, 0);

        // Zoom in + move up simultaneously
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / zoomTime;

            cam.fieldOfView = Mathf.Lerp(originalFOV, targetFOV, t);
            transform.position = Vector3.Lerp(originalPos, upPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(zoomWaitTime);

        // Zoom out + move down
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / zoomTime;

            cam.fieldOfView = Mathf.Lerp(targetFOV, originalFOV, t);
            transform.position = Vector3.Lerp(upPos, originalPos, t);

            yield return null;
        }

        // Ensure camera ends EXACTLY where it started
        cam.fieldOfView = originalFOV;
        transform.position = originalPos;
    }
}
