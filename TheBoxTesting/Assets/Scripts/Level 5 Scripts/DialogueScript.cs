using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueScript : MonoBehaviour
{
    public float waitTime = 0.05f;
    public string dialogueText = "Shiver me timbers, a player who\ngot to Level 5...you ain't so tuff\nbuddy.  ... .. -..-";
    public GameObject dialoguePanel;
    public TMP_Text textForm;

    public Level4GameManager gameManager;
    public AudioSource DIALOGUESFX;

    private Coroutine typingCoroutine;
    private int counter = 0;
    private bool theUIOn = false;

    private void OnMouseDown()
    {
        if (gameManager.UIEnabled && !theUIOn) return;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (!theUIOn)
            gameManager.UIEnabled = true;

        theUIOn = !theUIOn;
        textForm.text = "";

        if (theUIOn)
        {
            dialoguePanel.SetActive(true);
            counter = 0;

            if (DIALOGUESFX != null)
                DIALOGUESFX.Play();

            typingCoroutine = StartCoroutine(TypeText());
        }
        else
        {
            dialoguePanel.SetActive(false);
            gameManager.UIEnabled = false;

            if (DIALOGUESFX != null)
                DIALOGUESFX.Stop();
        }
    }

    IEnumerator TypeText()
    {
        while (counter < dialogueText.Length)
        {
            if (dialogueText[counter] == '\\')
            {
                textForm.text += dialogueText[counter];
                counter++;
            }

            textForm.text += dialogueText[counter];
            counter++;

            yield return new WaitForSeconds(waitTime);
        }

        typingCoroutine = null;

        if (DIALOGUESFX != null)
            DIALOGUESFX.Stop();
    }
}
