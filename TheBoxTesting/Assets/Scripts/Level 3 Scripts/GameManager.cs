using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentStage = 0;

    [Header("Correct Items By Stage")]
    public string[] correctItems;

    [Header("Collected Items")]
    public string[] collectedItems;

    private void Awake()
    {
        Instance = this;

        collectedItems = new string[correctItems.Length];
    }

    public void CollectItem(string itemName)
    {
        collectedItems[currentStage] = itemName;
    }

    public void AdvanceStage()
    {
        currentStage++;
    }

    public bool IsCorrect()
    {
        Debug.Log(collectedItems);
        for (int i = 0; i < correctItems.Length; i++)
        {
            if (collectedItems[i] != correctItems[i])
            {
                Debug.Log(collectedItems[i]);
                return false;
            }
        }
        return true;
    }
}
