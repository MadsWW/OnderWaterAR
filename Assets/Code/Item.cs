using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ItemIndexNr;
    public string ItemDescrip;

    //private Image imageItem; -- ReAdd if needed.


    //Set Fields For All Items in the scene from another script.
    public void SetFields(Image img, string descrip, int indexNr)
    {
        //imageItem = img;
        ItemDescrip = descrip;
        ItemIndexNr = indexNr;
    }
}
