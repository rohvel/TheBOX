using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour
{
    public GameObject cloudComputingPopUp;
    public Level4GameManager gameManager;

    private void OnMouseDown()
    {
        cloudComputingPopUp.SetActive(true);
        gameManager.UIEnabled = true;
    }


}
