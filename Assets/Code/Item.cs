using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemIndexNr;
    public string ItemDescrip;


    //Set Fields For All Items in the scene from another script.
    public void SetFields(string descrip, int indexNr)
    {
        ItemDescrip = descrip;
        ItemIndexNr = indexNr;
    }
}
