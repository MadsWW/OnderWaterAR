using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Image imageItem;
    private string itemDescrip;
    private int itemIndex;

    private UIController uiControl;

    public string ItemDescrip
    {
        get
        {
            return itemDescrip;
        }
    }

    public Item(Image img, string descrip, int indexNr)
    {
        imageItem = img;
        itemDescrip = descrip;
        itemIndex = indexNr;
    }

    private void Start()
    {
        itemDescrip = "Test UI";
        uiControl = GameObject.FindObjectOfType<UIController>();
    }

    private void OnMouseUp()
    {
        //Added to Inventory or open UI button to take item.
        Debug.Log("Item Clicked" + name);
        uiControl.OpenDescriptionUI(itemDescrip);
    }

    private void OnMouseDrag()
    {
        //When dragging the item
        Debug.Log("Dragging Item" + name);
    }
}
