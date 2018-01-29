using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLevelItems : MonoBehaviour {

    private List<Item> HighlightableItems = new List<Item>();

    private void Start ()
    {
        gManager = FindObjectOfType<GameManager>();
        zoom = FindObjectOfType<Zoom>();
        AddItemToList();
    }

    private void AddItemToList()
    {
        foreach (Item item in GetComponentsInChildren<Item>())
        {
            HighlightableItems.Add(item);
        }
    }
}
