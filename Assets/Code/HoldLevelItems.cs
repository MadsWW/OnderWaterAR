using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLevelItems : MonoBehaviour {

    public Item[] HighlightableItems;
    private GameManager gManager;
    private Zoom zoom;

    [HideInInspector]
    public bool isActive = false;

    

    private void Start ()
    {
        gManager = FindObjectOfType<GameManager>();
        zoom = FindObjectOfType<Zoom>();
        AddItemToList();
    }

    private void AddItemToList()
    {
        HighlightableItems = GetComponentsInChildren<Item>();
    }

    public void SendItemList()
    {
        if (isActive)
        {
            //gManager.AddItemsToActiveList(HighlightableItems);
            zoom.SetActiveLevel(gameObject);

        }
        else if (!isActive)
        {
            //gManager.EmptyActiveItemList();
            zoom.EmpyActiveLevel();
        }
    }
}
