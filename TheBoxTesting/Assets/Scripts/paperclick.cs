using UnityEngine; // needed for Unity
using UnityEngine.UI; // needed for UI

public class PaperClick : MonoBehaviour
{
    public GameObject panel; // the popup panel
    public Text text;        // the text inside the panel

    void OnMouseDown()
    {
        panel.SetActive(true);    // show the panel
    }
    public void ClosePanel()
{
    panel.SetActive(false);
    }
}