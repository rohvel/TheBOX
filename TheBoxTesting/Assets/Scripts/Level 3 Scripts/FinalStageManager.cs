using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalStageManager : MonoBehaviour
{
    public static FinalStageManager Instance;

    public GameObject xMark;
    public GameObject restartButton;
    public FinalDoor finalDoor;
    public AudioSource CORRECTSFX;
    public AudioSource INCORRECTSFX;

    private void Awake()
    {
        Instance = this;
    }

    public void PrepareFinalStage()
    {
        xMark.SetActive(false);
        restartButton.SetActive(false);

        if (GameManager.Instance.IsCorrect())
        {
            if (CORRECTSFX != null)
                CORRECTSFX.Play();

            finalDoor.objectPicked = true;
            finalDoor.OpenDoor();
        }
        else
        {
            if (INCORRECTSFX != null)
                INCORRECTSFX.Play();

            xMark.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void RestartToHome()
    {
        SceneManager.LoadScene("Level3");
    }
}
