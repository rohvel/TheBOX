using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalStageManager : MonoBehaviour
{
    public static FinalStageManager Instance;

    [Header("Final Stage Objects")]
    public GameObject xMark;
    public GameObject restartButton;
    public FinalDoor finalDoor;

    private void Awake()
    {
        Instance = this;

    }

    public void PrepareFinalStage()
    {
        xMark.SetActive(false);
        restartButton.SetActive(false);

        // Check correctness immediately
        if (GameManager.Instance.IsCorrect())
        {
            // allow clicking the final door
            finalDoor.objectPicked = true;
            finalDoor.OpenDoor();
        }
        else
        {   
            
            xMark.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    public void RestartToHome()
    {
        SceneManager.LoadScene("Level3");
    }
}
