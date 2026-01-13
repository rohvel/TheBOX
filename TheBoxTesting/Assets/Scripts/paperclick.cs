using UnityEngine;
using UnityEngine.UI;

public class PaperClick : MonoBehaviour
{
    public GameObject panel;
    public Text text;
    public AudioSource UISFX;

    void OnMouseDown()
    {
        panel.SetActive(true);
        if (UISFX != null)
            UISFX.Play();
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
