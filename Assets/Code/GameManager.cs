using System;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public static Item selectedItem;
    
    [Header("Start Highlight After X Seconds")]
    public int HighlightAfterSec;

    [Header("Highlight Items List Per Level")]
    public List<Item> LevelOneItems;
    public List<Item> LevelTwoItems;
    public List<Item> LevelThreeItems;

    [Header("Do NOT Touch!")]
    public Camera cam;
    public Shader normalShader;
    public Shader outlineShader;

    private RaycastHit hit;

    private int randomNumber = 0;
    private int previousNumber = 0;


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


    private void Start()
    {
        InvokeRepeating("HighlightItem", HighlightAfterSec, HighlightAfterSec); 
    }



    private void HighlightItem()
    {
        if(LevelOneItems == null)
        {
            throw new ArgumentNullException("There are no Imporant Items in the Scene");
        }

        if(selectedItem != null)
        {
            selectedItem.GetComponent<Renderer>().material.shader = normalShader;
        }

        randomNumber = RandomNumber();
        selectedItem = LevelOneItems[randomNumber];
        selectedItem.GetComponent<Renderer>().material.shader = outlineShader;
    }

    private int RandomNumber()
    {
        
        int ranNumber = UnityEngine.Random.Range(0, LevelOneItems.Count);

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
