using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class doorcode : MonoBehaviour
{
    public static bool hasKey = false;
    public Texture2D closedTexture;
    public Texture2D openTexture;
    public TMP_Text messageText;
    public AudioSource audioSource;

    [Header("Camera Zoom on Unlock")]
    public Camera sceneCamera;
    public float zoomFOV = 30f;
    public float zoomDuration = 1f;
    public float zoomMoveDistance = 2f; // how far the camera moves toward the door
    public Color proceedingColor = Color.cyan;
    [Header("Locked Popup UI")]
    public CanvasGroup popupPanel;
    public float popupFadeDuration = 0.25f;
    public Color lockedColor = new Color(1f, 0.6f, 0.2f); // warm orange

    bool doorIsOpen = false;
    MeshRenderer mr;
    bool interactionLocked = false;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.mainTexture = closedTexture;
        if (popupPanel != null)
        {
            popupPanel.alpha = 0f;
            popupPanel.blocksRaycasts = false;
            popupPanel.interactable = false;
        }
    }

    void OnMouseDown()
    {
        if (interactionLocked) return;
        if (!hasKey)
        {
            if (popupPanel != null)
            {
                StartCoroutine(ShowLockedPopup());
            }
            else
            {
                messageText.text = "The door is locked!";
                StartCoroutine(ClearMessageAfterDelay(2f));
            }

        }
        else
        {
            messageText.text = "";

            if (!doorIsOpen)
            {
                mr.material.mainTexture = openTexture;
                doorIsOpen = true;
                interactionLocked = true;
                if (messageText != null)
                {
                    messageText.color = Color.white;
                    string hex = ColorUtility.ToHtmlStringRGB(proceedingColor);
                    messageText.text = "<b>Door Unlocked</b>\n<color=#" + hex + ">Proceeding...</color>";
                }

                StartCoroutine(ZoomCameraAndLoad());
            }
        }
    }

    IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.text = "";
    }

    IEnumerator ShowLockedPopup()
    {
        if (popupPanel == null)
        {
            yield break;
        }

        popupPanel.alpha = 0f;
        popupPanel.blocksRaycasts = true;
        popupPanel.interactable = true;
        if (messageText != null)
        {
            messageText.color = lockedColor;
            messageText.text = "<b>Locked</b>\nYou need a key to open this door.";
        }

        float t = 0f;
        while (t < popupFadeDuration)
        {
            t += Time.deltaTime;
            popupPanel.alpha = Mathf.Lerp(0f, 1f, t / popupFadeDuration);
            yield return null;
        }
        popupPanel.alpha = 1f;

        yield return new WaitForSeconds(1.6f);

        t = 0f;
        while (t < popupFadeDuration)
        {
            t += Time.deltaTime;
            popupPanel.alpha = Mathf.Lerp(1f, 0f, t / popupFadeDuration);
            yield return null;
        }
        popupPanel.alpha = 0f;
        popupPanel.blocksRaycasts = false;
        popupPanel.interactable = false;

        if (messageText != null)
            messageText.text = "";
    }

    IEnumerator ZoomCameraAndLoad()
    {
        Camera cam = sceneCamera != null ? sceneCamera : Camera.main;
        if (cam == null)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Level2");
            yield break;
        }

        float startFOV = cam.fieldOfView;
        float targetFOV = zoomFOV;
        Vector3 startPos = cam.transform.position;
        Vector3 directionToDoor = (transform.position - startPos).normalized;

        bool allowMove = true;
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (var c in canvases)
        {
            if (c.renderMode == RenderMode.ScreenSpaceCamera && c.worldCamera == cam)
            {
                allowMove = false;
                break;
            }
        }

        Vector3 targetPos = allowMove ? startPos + directionToDoor * zoomMoveDistance : startPos;

        float elapsed = 0f;
        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / zoomDuration);
            cam.fieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            if (allowMove)
                cam.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level2");
    }

}

