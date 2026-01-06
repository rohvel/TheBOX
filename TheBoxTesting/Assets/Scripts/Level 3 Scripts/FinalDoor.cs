using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinalDoor : MonoBehaviour
{
    [Header("Door Materials")]
    public Material closedMaterial;
    public Material openMaterial;

    [Header("Camera")]
    public CameraController cameraController;

    [Header("Final Stage UI")]
    public GameObject xMark;
    public GameObject restartButton;

    private MeshRenderer meshRenderer;
    private bool isOpen = false;

    [HideInInspector]
    public bool objectPicked = false; // <-- This is the flag FinalStageManager sets

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
            meshRenderer.material = closedMaterial;

        if (xMark != null) xMark.SetActive(false);
        if (restartButton != null) restartButton.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Only allow interaction if the player has collected all items
        if (!objectPicked)
        {
            if (xMark != null) xMark.SetActive(true);
            if (restartButton != null) restartButton.SetActive(true);
            return;
        }
        else {
            OpenDoor();

            if (cameraController != null)
                StartCoroutine(ZoomAndLoadWin());
            else
                SceneManager.LoadScene("HomeScreen");
        }
    }

    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;

        if (meshRenderer != null && openMaterial != null)
            meshRenderer.material = openMaterial;
    }

    private IEnumerator ZoomAndLoadWin()
    {
        if (cameraController != null)
            yield return cameraController.ZoomFOVAndMoveUp();

        SceneManager.LoadScene("HomeScreen");
    }
}
