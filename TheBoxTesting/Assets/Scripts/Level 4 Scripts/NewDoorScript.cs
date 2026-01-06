using UnityEngine;
using System.Collections;

public class NewDoorScript : MonoBehaviour
{
    [Header("Door Materials")]
    public Material closedMaterial;
    public Material openMaterial;

    [Header("Stage Settings")]
    public GameObject nextStage;
    public Level4GameManager gameManager;

    [Header("Lock Picked")]
    public bool lockPicked = false;

    private MeshRenderer meshRenderer;
    private bool isOpen = false;

    [Header("Camera")]

    public CameraController cameraController;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = closedMaterial;
    }

    private void OnMouseDown()
    {
        if (!lockPicked) return;
        if (gameManager.UIEnabled) return;

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
        if (transform.parent != null)
            transform.parent.gameObject.SetActive(false);        
        if (nextStage != null)
            nextStage.SetActive(true);
        meshRenderer.material = closedMaterial;
        isOpen = false;
    }


}
