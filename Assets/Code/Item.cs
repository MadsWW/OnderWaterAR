using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ItemIndexNr;

    private Image imageItem;
    public string itemDescrip;
    private int itemIndex;

    private UIController uiControl;

    //Set Fields For All Items in the scene from another script.
    public void SetFields(Image img, string descrip, int indexNr)
    {
        imageItem = img;
        itemDescrip = descrip;
        itemIndex = indexNr;
    }

    // Load all necessairy Classes.
    private void Awake()
    {
        uiControl = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ClickedOnItem();
        }
    }

    //Make Description UI pop up with description of this item.
    private void ClickedOnItem()
    {
        uiControl.OpenDescriptionUI(gameObject, itemDescrip);
        ButtonController.selectedItem = this;
        Debug.Log(this.name);
    }
}
