using System;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {


    #region Private_Variables
    private static GameManager gameManager;
    private Item selectedItem;
    private List<Item> activeLevelItemList = new List<Item>();

    private int randomNumber = 0;
    private int previousNumber = 0;
    #endregion

    #region Public_Variables
    [Header("Hightlight Options")]
    public float StartHighlightAfterSec;
    public float RepeatHighlightAfterSec;
    public float StopHightlightAfterSec;

    [Header("Do NOT Touch Unless Empty")]
    public Shader normalShader;
    public Shader outlineShader;

    
    #endregion


    // Handles everything on Awake
    private void Awake()
    {
        CheckForGameManager();
    }

    private void OnEnable()
    {
        DefaultTrackableEventHandler.OnLevelChange += new DefaultTrackableEventHandler.LevelChanged(AddItemsToActiveList);
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
    void AddItemsToActiveList(GameObject level, bool isActive)
    {
        if (isActive)
        {
            Item[] tempItemArray = level.GetComponent<HoldLevelItems>().HighlightableItems;
            foreach (Item item in tempItemArray)
            {
                activeLevelItemList.Add(item);
            }

            InvokeRepeating("HighlightItem", StartHighlightAfterSec, RepeatHighlightAfterSec);
            Debug.Log(level.name);
        }
        else if (!isActive)
        {
            if (activeLevelItemList != null)
            {
                activeLevelItemList.Clear();
                CancelInvoke("HighlightItem");
            }
            Debug.Log("Event Didnt do its thing!");
        }
    }

    //Clears the activeitemlist and stops hightlighting
    public void EmptyActiveItemList()
    {

    }
}
