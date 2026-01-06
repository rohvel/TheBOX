using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class doorcode : MonoBehaviour
{
    public static bool hasKey = false;
    public Texture2D closedTexture;
    public Texture2D openTexture;
    public TMP_Text messageText;

    bool doorIsOpen = false;
    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.mainTexture = closedTexture;
    }

    void OnMouseDown()
    {
        if (!hasKey)
        {
            messageText.text = "The door is locked!";     
            StartCoroutine(ClearMessageAfterDelay(2f));

        }
        else
        {
            messageText.text = "";

            if (!doorIsOpen)
            {
                mr.material.mainTexture = openTexture;
                doorIsOpen = true;
                StartCoroutine(DoorOpenDelay());
                

            }
            else
            {
                mr.material.mainTexture = closedTexture;
                doorIsOpen = false;
            }
        }
    }

    IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.text = "";
    }

    IEnumerator DoorOpenDelay()
{
    yield return new WaitForSeconds(2f); 
    SceneManager.LoadScene("Level2");
}

}

