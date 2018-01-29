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

    #endregion // Private_Variables

    #region Public_Variables

    [Header("Hightlight Options")]
    public float StartHighlightAfterSec;
    public float RepeatHighlightAfterSec;
    public float StopHightlightAfterSec;

    [Header("Do NOT Touch Unless Empty")]
    public Shader normalShader;
    public Shader outlineShader;

    #endregion // Public_Variables


    // Handles everything on Awake + Add method to levelchangeevent
    private void Awake()
    {
        CheckForGameManager();
        DefaultTrackableEventHandler.OnLevelChange += new DefaultTrackableEventHandler.LevelChanged(ChangeItemsToActiveList);
    }

    // Removes method from levelchangeevent.
    private void OnDestroy()
    {
        DefaultTrackableEventHandler.OnLevelChange -= new DefaultTrackableEventHandler.LevelChanged(ChangeItemsToActiveList);
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


    #region HANDLES_HIGHLIGHT_METHODS
    //Sets current active level List and starts highligting
    private void ChangeItemsToActiveList(GameObject level, bool isActive)
    {
        if (isActive)
        {
            Item[] tempItemArray = level.GetComponent<HoldLevelItems>().HighlightableItems;
            foreach (Item item in tempItemArray)
            {
                activeLevelItemList.Add(item);
            }

            InvokeRepeating("HighlightItem", StartHighlightAfterSec, RepeatHighlightAfterSec);
        }
        else if (!isActive)
        {
            if (activeLevelItemList != null)
            {
                activeLevelItemList.Clear();
                CancelInvoke("HighlightItem");
            }
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

    // Removes Highlight after x seconds.
    private void RemoveHighlight()
    {
        selectedItem.GetComponent<Renderer>().material.shader = normalShader;
    }
    #endregion // HANDLES_HIGHLIGHT_METHODS

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


}
