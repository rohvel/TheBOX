using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndCreditsManager : MonoBehaviour
{
    public TMP_Text mainText;
    public float delay = 2f;

    void Start()
    {
        StartCoroutine(CreditsSequence());
    }

    IEnumerator CreditsSequence()
    {
        mainText.text = "Congratulations";
        yield return new WaitForSeconds(delay);

        mainText.text = "You Beat The Box";
        yield return new WaitForSeconds(delay);

        mainText.text = "Game Design\n\nRohan V, Nam N";
        yield return new WaitForSeconds(delay);

        mainText.text = "Programming\n\nVihaan M\nRiyan N\nRohan V";
        yield return new WaitForSeconds(delay);

        mainText.text = "Art\n\nRohan V, Nam N";
        yield return new WaitForSeconds(delay);

        mainText.text = "Sound\n\nBlaise B";
        yield return new WaitForSeconds(delay);

        mainText.text = "Thanks for playing :)";
    }

    public void SkipToMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
