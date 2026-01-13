using UnityEngine;
using UnityEngine.UI;

public class BlacklightUIToggle : MonoBehaviour
{
    public Image buttonImage;
    public Sprite flashlightOffSprite;
    public Sprite flashlightOnSprite;
    
    private BlacklightController blacklightController;

    private void Start()
    {
        blacklightController = FindObjectOfType<BlacklightController>();
        UpdateButtonSprite();
    }

    public void OnToggleButtonPressed()
    {
        if (blacklightController != null)
        {
            blacklightController.ToggleBlacklight();
            UpdateButtonSprite();
        }
    }

    private void UpdateButtonSprite()
    {
        if (buttonImage != null && blacklightController != null && blacklightController.blacklight != null)
        {
            buttonImage.sprite = blacklightController.blacklight.enabled ? flashlightOnSprite : flashlightOffSprite;
        }
    }
}