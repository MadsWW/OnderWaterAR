using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerOld : MonoBehaviour {

    //private static GameManager gameManager;

    public static Item selectedItem;
    //public static Player player;

    [Header("Start Highlight After")]
    public int HighlightAfterSec;
    [Header("Highlight Item List")]
    public List<Item> importantItems;



    [Header("Do NOT Touch!")]
    public Camera cam;
    public Shader normalShader;
    public Shader outlineShader;

    //private UIController uiControl;
    private RaycastHit hit;

    private int randomNumber = 0;
    private int previousNumber = 0;


    private void Awake()
    {
        //CheckForGameManager();
    }

    private void Start()
    {
        //uiControl = FindObjectOfType<UIController>();
        InvokeRepeating("HighlightItem", HighlightAfterSec, HighlightAfterSec);
    }


    private void Update()
    {
        // Remove Comment before this method to make clicking on items available.
        //WhatDidIClickOn(); 
    }

    //Check what Clicked On
    private void WhatDidIClickOn()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    Item item = hit.collider.GetComponent<Item>();
                    string itemDescription = hit.collider.gameObject.GetComponent<Item>().ItemDescrip;
                    ClickedOnItem(item);
                }
            }
        }
    }

    // Make bool functions to check selectedItem.
    private void ClickedOnItem(Item obj)
    {
        //uiControl.OpenDescriptionUI(obj, itemDescrip);
        if (selectedItem == null)
        {
            selectedItem = obj;
            selectedItem.GetComponent<Renderer>().material.shader = outlineShader;
        }

        else if (selectedItem == obj)
        {
            selectedItem.GetComponent<Renderer>().material.shader = normalShader;
            selectedItem = null;
        }

        else if (selectedItem != obj)
        {
            selectedItem.GetComponent<Renderer>().material.shader = normalShader;
            selectedItem = obj;
            selectedItem.GetComponent<Renderer>().material.shader = outlineShader;
        }

    }
    /*
    // Singleton for GameManager
    private void CheckForGameManager()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            //gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }
    */

    private void HighlightItem()
    {
        if (importantItems == null)
        {
            throw new ArgumentNullException("There are no Imporant Items in the Scene");
        }

        if (selectedItem != null)
        {
            selectedItem.GetComponent<Renderer>().material.shader = normalShader;
        }


        randomNumber = RandomNumber();
        Debug.Log(randomNumber);
        selectedItem = importantItems[randomNumber];

        selectedItem.GetComponent<Renderer>().material.shader = outlineShader;

    }

    private int RandomNumber()
    {

        int ranNumber = UnityEngine.Random.Range(0, importantItems.Count);

        if (ranNumber == previousNumber)
        {
            return RandomNumber();
        }
        else
        {
            previousNumber = ranNumber;
            return ranNumber;
        }
    }
}
