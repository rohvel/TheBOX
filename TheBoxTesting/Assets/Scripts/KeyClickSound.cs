using UnityEngine;

public class KeyClickSound : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find("UISFX")
            .GetComponent<AudioSource>()
            .PlayOneShot(
                GameObject.Find("UISFX").GetComponent<AudioSource>().clip
            );
    }
}
