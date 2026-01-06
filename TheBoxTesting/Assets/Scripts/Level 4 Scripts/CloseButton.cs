using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    Button myButton;
    public Level4GameManager gameManager;

    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    } 

    void OnButtonClick()
    {
        gameManager.UIEnabled = false;
        transform.parent.gameObject.SetActive(false);
    }
}
