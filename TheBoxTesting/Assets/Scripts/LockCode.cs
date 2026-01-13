using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LockCode : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField inputField;
    public string correctCode = "5361";
    public GameObject successPanel;
    public GameObject failPanel;
    public AudioSource CORRECTSFX;
    public AudioSource INCORRECTSFX;

    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void CheckCode()
    {
        if (inputField.text == correctCode)
        {
            successPanel.SetActive(true);
            failPanel.SetActive(false);
            if (CORRECTSFX != null)
                StartCoroutine(PlayCorrectAndLoad());
        }
        else
        {
            failPanel.SetActive(true);
            successPanel.SetActive(false);
            if (INCORRECTSFX != null)
                INCORRECTSFX.Play();
        }
    }

    IEnumerator PlayCorrectAndLoad()
    {
        if (CORRECTSFX != null)
            CORRECTSFX.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level3");
    }

    public void CloseSuccessPanel()
    {
        successPanel.SetActive(false);
    }

    public void CloseFailPanel()
    {
        failPanel.SetActive(false);
    }
}
