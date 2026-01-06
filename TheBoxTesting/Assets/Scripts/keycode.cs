using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnMouseDown()
    {
        doorcode.hasKey = true;  
        Destroy(gameObject);      
    }
}
