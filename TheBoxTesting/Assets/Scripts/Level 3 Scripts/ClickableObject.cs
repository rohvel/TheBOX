using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public string itemName;               // name of the object for GameManager
    public Door doorInStage;              // door that must become pickable
    public GameObject otherObject;        // the object that disappears after choosing

    private bool clicked = false;

    private void OnMouseDown()
    {
        if (clicked) return;

        clicked = true;

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
