using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Material closedMaterial;
    public Material openMaterial;
    public GameObject nextStage;
    [HideInInspector] public bool objectPicked = false;
    public CameraController cameraController;
    public AudioSource DOORSFX;

    private MeshRenderer meshRenderer;
    private bool isOpen = false;

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

        GameManager.Instance.AdvanceStage();
    }
}
