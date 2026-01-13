using UnityEngine;

public class RestartButton3D : MonoBehaviour
{
    private void OnMouseDown()
    {
        FinalStageManager.Instance.RestartToHome();
    }
}
