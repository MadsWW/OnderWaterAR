using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private static GameManager gameManager;
       
    public static Player player;

    private UIController uiControl;

    public Camera cam;



    private void Awake()
    {
        CheckForGameManager();
        CreatePlayer("Mads");
    }

    private void Start()
    {
        uiControl = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        WhatDidIClickOn();
    }

    private void WhatDidIClickOn()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    GameObject item = hit.collider.gameObject;
                    string itemDescription = hit.collider.gameObject.GetComponent<Item>().itemDescrip;
                    ClickedOnItem(item, itemDescription);
                }
            }
        }
    }

    private void ClickedOnItem(GameObject obj, string itemDescrip)
    {
        uiControl.OpenDescriptionUI(obj, itemDescrip);
        ButtonController.selectedItem = obj.GetComponent<Item>();
        Debug.Log(" SelectItem: " + ButtonController.selectedItem);
    }

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


    //!!Make CheckForPlayer later, if there is non, let the player create one.!!
    private void CreatePlayer(string name)
    {
        if (player == null)
        {
            player = new Player(name);
            Debug.Log("New player named: " + name);
        } else if (player != null)
        {
            Debug.Log("A player already exists, called: " + player.Name );
        }
    }

    
}
