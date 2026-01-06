using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level5RoomCodeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Button myButton;
    public TMP_InputField inputField;
    public Level4GameManager gameManager;

    public GameObject incorrectPanel;
    public float waitTime = 0.5f;

    private string textInInput;

    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    } 

    void OnButtonClick()
    {
        textInInput = inputField.text.ToLowerInvariant();
        if (textInInput == "85164" || textInInput == "8 5 1 6 4")
        {
            SceneManager.LoadScene("HomeScreen");
        }
        else
        {
            incorrectPanel.SetActive(true);
            StartCoroutine(WaitForBit());
        }
    }

    IEnumerator WaitForBit()
    {
        inputField.text = "";
        yield return new WaitForSeconds(waitTime);
        incorrectPanel.SetActive(false);
        
    }
}
