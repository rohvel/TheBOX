using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class InputButtonScript : MonoBehaviour
{
    Button myButton;
    public TMP_InputField inputField;
    public Level4GameManager gameManager;
    public GameObject customLock;
    public GameObject incorrectPanel;
    public NewDoorScript customDoor;
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
        if (textInInput == "cloud computing" || textInInput == "cloudcomputing" || textInInput == "cloud computer" || textInInput == "cloudcomputer")
        {
            customLock.SetActive(false);
            transform.parent.gameObject.SetActive(false);
            gameManager.UIEnabled = false;
            customDoor.lockPicked = true;
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
