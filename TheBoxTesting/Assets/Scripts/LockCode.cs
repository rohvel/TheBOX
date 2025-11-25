using UnityEngine;
using TMPro;  // needed for TMP input field

public class LockCode : MonoBehaviour
{
    public GameObject panel;         // the lock popup panel
    public TMP_InputField inputField; // where player types code
    public string correctCode = "5361";  // the correct code
    public GameObject successPanel;  // shows when code is right
    public GameObject failPanel;     // shows when code is wrong

    public void OpenPanel()  // show the lock panel
    {
        panel.SetActive(true);
    }

    public void ClosePanel()  // hide the lock panel
    {
        panel.SetActive(false);
    }

    public void CheckCode()  // check typed code
    {
        if (inputField.text == correctCode)  // if code correct
        {
            panel.SetActive(false);         // hide lock panel
            successPanel.SetActive(true);   // show success popup
            failPanel.SetActive(false);   // hide fail popup

        }



        else  // wrong code
        {
            failPanel.SetActive(true);      // show fail popup
            successPanel.SetActive(false);  // hide success popup
        }
        }
        
    

    public void CloseSuccessPanel()  // hide success panel

    {
        successPanel.SetActive(false);
    }

    public void CloseFailPanel()  // hide fail panel
    {
        failPanel.SetActive(false);
    }
}
