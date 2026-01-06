using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [Header("Door Materials")]
    public Material closedMaterial;
    public Material openMaterial;

    [Header("Stage Settings")]
    public GameObject nextStage;

    [HideInInspector]
    public bool objectPicked = false;

    private MeshRenderer meshRenderer;
    private bool isOpen = false;

    [Header("Camera")]
    public CameraController cameraController;

    // Track if the first stage was 0
    private static bool firstStageChecked = false;
    private static bool firstStageWasZero = false;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = closedMaterial;

        if (!firstStageChecked)
        {
            firstStageWasZero = (GameManager.Instance.currentStage == 0);
            firstStageChecked = true;
        }
    }

    private void OnMouseDown()
    {
        if (!objectPicked) return;

        StartCoroutine(AdvanceStageAfterDelay(1f));
    }

    public void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        meshRenderer.material = openMaterial;
    }

    private IEnumerator AdvanceStageAfterDelay(float delay)
    {
        OpenDoor();

        if (cameraController != null)
            cameraController.StartCoroutine(cameraController.ZoomFOVAndMoveUp());

        yield return new WaitForSeconds(delay);

        int nextStageNum = GameManager.Instance.currentStage + 1;

        // If this is the final stage (stage 5)


        // Disable current stage
        if (transform.parent != null)
            transform.parent.gameObject.SetActive(false);

        // Enable next stage
        if (nextStage != null)
            nextStage.SetActive(true);

        GameManager.Instance.AdvanceStage();
    }
}
