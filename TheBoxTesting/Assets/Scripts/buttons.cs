using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public AudioSource BUTTONSFX;
    public GameObject creditsPanel;

    IEnumerator LoadSceneAfterDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void OnButtonClick()
    {
        if (BUTTONSFX != null) BUTTONSFX.Play();
        StartCoroutine(LoadSceneAfterDelay(5f, "Level1"));
    }

    void Start()
    {
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        if (BUTTONSFX != null) BUTTONSFX.Play();
        StartCoroutine(LoadSceneAfterDelay(0.1f, "Level1"));
    }

    public void OptionsButton()
    {
        if (BUTTONSFX != null) BUTTONSFX.Play();
        if (OptionsManager.Instance != null)
            OptionsManager.Instance.OpenOptions();
    }

    public void ExitButton()
    {
        if (BUTTONSFX != null) BUTTONSFX.Play();
        Application.Quit();
    }

    public void CreditsButton()
    {
        if (BUTTONSFX != null) BUTTONSFX.Play();
        if (creditsPanel != null)
            creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        if (BUTTONSFX != null) BUTTONSFX.Play();
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
    }
}
