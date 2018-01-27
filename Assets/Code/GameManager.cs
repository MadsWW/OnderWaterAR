using System;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public static Item selectedItem;

    [Header("Hightlight Options")]
    public float StartHighlightAfterSec;
    public float RepeatHighlightAfterSec;
    public float StopHightlightAfterSec;

    [Header("Do NOT Touch Unless Empty")]
    public Camera cam; // Make private and FindObj at awake/Start
    public Shader normalShader;
    public Shader outlineShader;

    private List<Item> activeLevelItemList = new List<Item>();

    private int randomNumber = 0;
    private int previousNumber = 0;

    // Handles everything on Awake
    private void Awake()
    {
        CheckForGameManager();
    }

    // Singleton for GameManager
    private void CheckForGameManager()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }


    // Set normal Shader to previous selectedItem and hightlightss the new one.
    private void HighlightItem()
    {
        if(activeLevelItemList == null)
        {
            throw new ArgumentNullException("The Hightlightable Item List is Empty.");
        }

        if(selectedItem != null)
        {
            selectedItem.GetComponent<Renderer>().material.shader = normalShader;
        }

        randomNumber = RandomNumber();
        selectedItem = activeLevelItemList[randomNumber];
        selectedItem.GetComponent<Renderer>().material.shader = outlineShader;

        Invoke("RemoveHighlight", StopHightlightAfterSec);
    }

    private void RemoveHighlight()
    {
        selectedItem.GetComponent<Renderer>().material.shader = normalShader;
    }

    // Calculates random number and checks if last value is not the same.
    private int RandomNumber()
    {
        
        int ranNumber = UnityEngine.Random.Range(0, activeLevelItemList.Count);

        if (ranNumber == previousNumber)
        {
            return RandomNumber(); 
        }
        else if(ranNumber != previousNumber)
        {
            previousNumber = ranNumber;
            return ranNumber;
        }

        throw new ArgumentException("Returned a value which was not expected");
    }

    //Sets current active level List and starts highligting
    public void AddItemsToActiveList(List<Item> items)
    {
        foreach(Item item in items)
        {
            activeLevelItemList.Add(item);
        }

        InvokeRepeating("HighlightItem", StartHighlightAfterSec, RepeatHighlightAfterSec);
    }

    //Clears the activeitemlist and stops hightlighting
    public void EmptyActiveItemList()
    {
        if (activeLevelItemList != null)
        {
            activeLevelItemList.Clear();
            CancelInvoke("HighlightItem");
        }
    }
}
