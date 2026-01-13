using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour
{
    public GameObject cloudComputingPopUp;
    public Level4GameManager gameManager;
    public AudioSource CORRECTSFX;
    public AudioSource INCORRECTSFX;

    private void OnMouseDown()
    {
        cloudComputingPopUp.SetActive(true);
        gameManager.UIEnabled = true;
    }

    public void SubmitAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            if (CORRECTSFX != null)
                CORRECTSFX.Play();
        }
        else
        {
            if (INCORRECTSFX != null)
                INCORRECTSFX.Play();
        }
    }
}
