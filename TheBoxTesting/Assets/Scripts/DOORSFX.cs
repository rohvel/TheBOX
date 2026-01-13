using UnityEngine;

public class DOORSFX: MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find("DOORSFX")
            .GetComponent<AudioSource>()
            .PlayOneShot(
                GameObject.Find("DOORSFX").GetComponent<AudioSource>().clip
            );
    }
}
