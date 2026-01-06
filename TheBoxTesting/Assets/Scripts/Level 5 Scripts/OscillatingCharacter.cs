using UnityEngine;

public class OscillatingCharacter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private MeshRenderer meshRenderer;

    public Material materialOne;
    public Material materialTwo;

    private bool usingOne;

    public float interval = 0.5f;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        InvokeRepeating(nameof(Swap),0f,interval);
    }

    void Swap()
    {
        meshRenderer.material = usingOne ? materialTwo : materialOne;
        usingOne = !usingOne;
    }
}
