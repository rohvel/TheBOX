using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinalDoor : MonoBehaviour
{
    public Material closedMaterial;
    public Material openMaterial;
    public CameraController cameraController;
    public GameObject xMark;
    public GameObject restartButton;
    public AudioSource DOORSFX;

    private MeshRenderer meshRenderer;
    private bool isOpen = false;
    [HideInInspector] public bool objectPicked = false;

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
        if (!objectPicked)
        {
            if (xMark != null) xMark.SetActive(true);
            if (restartButton != null) restartButton.SetActive(true);
            return;
        }
        else
        {
            OpenDoor();
            if (cameraController != null)
                StartCoroutine(ZoomAndLoadWin());
            else
                SceneManager.LoadScene("Level4");
        }
    }

    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;
        if (meshRenderer != null && openMaterial != null)
            meshRenderer.material = openMaterial;
        if (DOORSFX != null)
            DOORSFX.Play();
    }

    private IEnumerator ZoomAndLoadWin()
    {
        if (cameraController != null)
            yield return cameraController.ZoomFOVAndMoveUp();
        SceneManager.LoadScene("Level4");
    }
}
