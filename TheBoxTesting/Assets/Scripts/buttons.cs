using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");

    }
    public void OptionsButton()
    {
        Debug.Log("options button pressed");

    }
    public void ExitButton()
    {
        Debug.Log("quit button pressed");
    }

    public void CreditsButton()
    {
        Debug.Log("credits button pressed");
    }
}
