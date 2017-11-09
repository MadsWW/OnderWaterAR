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

    //Set Fields For All Items in the scene from another script.
    public void SetFields(Image img, string descrip, int indexNr)
    {
        imageItem = img;
        itemDescrip = descrip;
        itemIndex = indexNr;
    }
}
