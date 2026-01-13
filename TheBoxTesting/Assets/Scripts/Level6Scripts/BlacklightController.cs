using UnityEngine;

public class BlacklightController : MonoBehaviour
{
    public Light blacklight;

    private void Start()
    {
        // Start with blacklight disabled
        if (blacklight != null)
        {
            blacklight.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleBlacklight();
        }
    }

    public void ToggleBlacklight()
    {
        if (blacklight != null)
        {
            blacklight.enabled = !blacklight.enabled;
        }
    }
}