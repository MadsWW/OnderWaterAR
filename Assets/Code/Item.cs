using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Image imageItem;
    private string itemDescrip;
    private int itemIndex;

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



    private void OnMouseOver()
    {
        //When mouse hovers over item
    }

    private void OnMouseDrag()
    {
        //When dragging the item
    }

    private void OnCollissionEnter()
    {
        //When collides with certain CollissionBoxes
    }


}
