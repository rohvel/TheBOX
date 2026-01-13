using UnityEngine;

public class UVClue : MonoBehaviour
{
    [Header("Clue Appearance")]
    public Material normalMaterial;  // Mirror's normal reflective material
    public Material uvMaterial;      // Material with binary visible (emissive)
    
    private MeshRenderer mr;
    private bool isRevealed = false;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        if (mr != null && normalMaterial != null)
        {
            mr.material = normalMaterial;  // Start with normal mirror appearance
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blacklight") && !isRevealed)
        {
            RevealClue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blacklight") && isRevealed)
        {
            HideClue();
        }
    }

    void RevealClue()
    {
        if (mr != null && uvMaterial != null)
        {
            mr.material = uvMaterial;
            isRevealed = true;
            Debug.Log("Binary revealed on mirror!");
        }
    }

    void HideClue()
    {
        if (mr != null && normalMaterial != null)
        {
            mr.material = normalMaterial;
            isRevealed = false;
            Debug.Log("Binary hidden on mirror!");
        }
    }
}