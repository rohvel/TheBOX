using UnityEngine;

public class DoorSwitcher : MonoBehaviour
{
    public int targetCameraIndex;
    public bool requiresKey = false;
    public string requiredKeyTag = "Key";

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!requiresKey || HasRequiredKey())
            {
                // Find CameraSwitcher in scene
                CameraSwitcher switcher = FindObjectOfType<CameraSwitcher>();
                if (switcher != null)
                {
                    switcher.SwitchToCamera(targetCameraIndex);
                }
            }
            else
            {
                Debug.Log("Need a key to open this door!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to switch to camera " + targetCameraIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private bool HasRequiredKey()
    {
        // Simple check - you can expand this
        GameObject key = GameObject.FindGameObjectWithTag(requiredKeyTag);
        return key != null;
    }
}