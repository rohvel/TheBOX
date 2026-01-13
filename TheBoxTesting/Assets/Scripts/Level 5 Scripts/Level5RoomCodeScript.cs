using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level5RoomCodeScript : MonoBehaviour
{
    Button myButton;
    public TMP_InputField inputField;
    public Level4GameManager gameManager;

    public GameObject incorrectPanel;
    public float waitTime = 0.5f;

    public AudioSource COMPLETESFX;
    public AudioSource INCORRECTSFX;

    private string textInInput;

    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    } 

    void OnButtonClick()
    {
        textInInput = inputField.text.ToLowerInvariant();
        if (textInInput == "85164" || textInInput == "8 5 1 6 4" || textInInput == "ITPM")
        {
            if (COMPLETESFX != null)
                StartCoroutine(PlayCompleteAndLoad());
            else
                SceneManager.LoadScene("EndScene");
        }
        else
        {
            if (INCORRECTSFX != null)
                INCORRECTSFX.Play();

            incorrectPanel.SetActive(true);
            StartCoroutine(WaitForBit());
        }
    }

    IEnumerator PlayCompleteAndLoad()
    {
        COMPLETESFX.Play();
        yield return new WaitForSeconds(COMPLETESFX.clip.length);
        SceneManager.LoadScene("EndScene");
    }

    IEnumerator WaitForBit()
    {
        inputField.text = "";
        yield return new WaitForSeconds(waitTime);
        incorrectPanel.SetActive(false);
    }
}
