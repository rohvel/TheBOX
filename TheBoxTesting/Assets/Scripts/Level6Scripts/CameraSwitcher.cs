using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public int currentCameraIndex = 0;

    private void Start()
    {
        // Ensure only the first camera is active and properly configured
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != null)
            {
                cameras[i].gameObject.SetActive(i == 0);
                
                // Disable Audio Listener on non-active cameras to prevent conflicts
                AudioListener listener = cameras[i].GetComponent<AudioListener>();
                if (listener != null && i != 0)
                {
                    listener.enabled = false;
                }
            }
        }
    }

    public void SwitchToNextCamera()
    {
        if (cameras.Length == 0) return;

        // Disable current camera and its audio listener
        if (cameras[currentCameraIndex] != null)
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
            AudioListener currentListener = cameras[currentCameraIndex].GetComponent<AudioListener>();
            if (currentListener != null)
            {
                currentListener.enabled = false;
            }
        }

        // Move to next
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Enable new camera and its audio listener
        if (cameras[currentCameraIndex] != null)
        {
            cameras[currentCameraIndex].gameObject.SetActive(true);
            AudioListener newListener = cameras[currentCameraIndex].GetComponent<AudioListener>();
            if (newListener != null)
            {
                newListener.enabled = true;
            }
        }

        Debug.Log("Switched to camera: " + currentCameraIndex);
    }

    public void SwitchToCamera(int index)
    {
        if (index < 0 || index >= cameras.Length || index == currentCameraIndex) return;

        // Disable current
        if (cameras[currentCameraIndex] != null)
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
            AudioListener currentListener = cameras[currentCameraIndex].GetComponent<AudioListener>();
            if (currentListener != null)
            {
                currentListener.enabled = false;
            }
        }

        // Enable target
        currentCameraIndex = index;
        if (cameras[currentCameraIndex] != null)
        {
            cameras[currentCameraIndex].gameObject.SetActive(true);
            AudioListener newListener = cameras[currentCameraIndex].GetComponent<AudioListener>();
            if (newListener != null)
            {
                newListener.enabled = true;
            }
        }
    }
}