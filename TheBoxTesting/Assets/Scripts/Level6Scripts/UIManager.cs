using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text roomLabel;
    public CameraSwitcher cameraSwitcher;

    private void Start()
    {
        UpdateRoomLabel();
    }

    public void OnNextRoomButton()
    {
        cameraSwitcher.SwitchToNextCamera();
        UpdateRoomLabel();
    }

    private void UpdateRoomLabel()
    {
        if (roomLabel != null && cameraSwitcher.cameras.Length > 0)
        {
            roomLabel.text = "Room " + (cameraSwitcher.currentCameraIndex + 1);
        }
    }
}