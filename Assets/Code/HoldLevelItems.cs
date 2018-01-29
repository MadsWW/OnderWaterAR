using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLevelItems : MonoBehaviour {

    public Item[] HighlightableItems;

    private void Awake ()
    {
        AddItemToList();
    }

    private void AddItemToList()
    {
        HighlightableItems = GetComponentsInChildren<Item>();
    }
}
