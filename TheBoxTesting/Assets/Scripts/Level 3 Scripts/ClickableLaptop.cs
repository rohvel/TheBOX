using UnityEngine;

public class ClickableLaptop : MonoBehaviour
{
    private bool clicked = false;

    private void OnMouseDown()
    {
        if (clicked) return;
        clicked = true;

        Debug.Log("click");
        FinalStageManager.Instance.PrepareFinalStage();
    }
}
