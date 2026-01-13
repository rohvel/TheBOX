using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string itemName;               
    public Door doorInStage;              
    public GameObject otherObject;        
    public AudioSource PICKUPSFX;         // sound played when the item is picked up

    private bool clicked = false;

    private void OnMouseDown()
    {
        if (clicked) return;

        clicked = true;

        // play pick-up sound
        if (PICKUPSFX != null)
            PICKUPSFX.Play();

        // store item
        GameManager.Instance.CollectItem(itemName);

        // remove both items
        gameObject.SetActive(false);
        if (otherObject != null)
            otherObject.SetActive(false);

        // tell door you picked something
        doorInStage.objectPicked = true;
    }
}
