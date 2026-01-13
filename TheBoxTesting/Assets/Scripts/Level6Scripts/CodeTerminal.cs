using UnityEngine;
using TMPro;

public class CodeTerminal : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    public FinalDoorLevel6 finalDoor;

    public void SubmitCode()
    {
        if (inputField.text == "205")
        {
            feedbackText.text = "ACCESS GRANTED";
            finalDoor.OpenDoor();
        }
        else
        {
            feedbackText.text = "INCORRECT CODE";
        }
        
        // Clear the feedback text after 3 seconds
        StartCoroutine(ClearFeedbackAfterDelay(3f));
    }

    private System.Collections.IEnumerator ClearFeedbackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        feedbackText.text = "";
    }
}