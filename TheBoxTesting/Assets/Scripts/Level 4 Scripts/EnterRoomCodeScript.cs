using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterRoomCodeScript : MonoBehaviour
{
    Button myButton;
    public TMP_InputField inputField;
    public Level4GameManager gameManager;

    public GameObject incorrectPanel;
    public float waitTime = 2f;

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
        if (textInInput == "67 79 79 76" || textInInput == "67797976" || textInInput == "067079079076" || textInInput == "067 079 079 076")
        {
            if (COMPLETESFX != null)
                StartCoroutine(PlayCompleteAndLoad());
            else
                SceneManager.LoadScene("Level5");
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
        SceneManager.LoadScene("Level5");
    }

    IEnumerator WaitForBit()
    {
        inputField.text = "";
        yield return new WaitForSeconds(waitTime);
        incorrectPanel.SetActive(false);
    }
}
