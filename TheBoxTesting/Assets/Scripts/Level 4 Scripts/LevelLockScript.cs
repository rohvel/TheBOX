using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLockScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Button myButton;
    public GameObject enterRoomCodePopUp; 
    public Level4GameManager level4GameManager;

    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);

    }

    void OnButtonClick()
    {
        enterRoomCodePopUp.SetActive(true);
        level4GameManager.UIEnabled = true;
    }
}
