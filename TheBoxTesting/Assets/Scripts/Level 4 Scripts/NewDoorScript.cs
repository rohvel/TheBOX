using UnityEngine;
using System.Collections;

public class NewDoorScript : MonoBehaviour
{
    public Material closedMaterial;
    public Material openMaterial;
    public GameObject nextStage;
    public Level4GameManager gameManager;
    public bool lockPicked = false;
    public CameraController cameraController;
    public AudioSource DOORSFX;

    private MeshRenderer meshRenderer;
    private bool isOpen = false;

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
        if (DOORSFX != null)
            DOORSFX.Play();
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
