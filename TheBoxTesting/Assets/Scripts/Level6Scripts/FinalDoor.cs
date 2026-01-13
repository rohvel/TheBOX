using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinalDoorLevel6 : MonoBehaviour
{
    public Texture2D closedTexture;
    public Texture2D openTexture;
    public string endSceneName = "EndScene";

    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.mainTexture = closedTexture;
    }

    public void OpenDoor()
    {
        mr.material.mainTexture = openTexture;
        StartCoroutine(EndGameDelay());
    }

    IEnumerator EndGameDelay()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(endSceneName);
    }
}