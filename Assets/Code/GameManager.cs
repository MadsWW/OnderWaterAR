using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public static GameObject selectedItem;
    public static Player player;

    private UIController uiControl;

    public Camera cam;

    public Shader normalShader;
    public Shader outlineShader;

    RaycastHit hit;


    private void Awake()
    {
        CheckForGameManager();
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
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    GameObject item = hit.collider.gameObject;
                    string itemDescription = hit.collider.gameObject.GetComponent<Item>().ItemDescrip;
                    ClickedOnItem(item, itemDescription);
                }
            }
        }
    }

    // Make bool functions to check selectedItem.
    private void ClickedOnItem(GameObject obj, string itemDescrip)
    {
        uiControl.OpenDescriptionUI(obj, itemDescrip);
        if (selectedItem == null)
        {
            selectedItem = obj;
        }

        if(selectedItem == obj)
        {
            selectedItem.GetComponent<Renderer>().material.shader = outlineShader;
        }

        if(selectedItem != obj)
        {
            selectedItem.GetComponent<Renderer>().material.shader = normalShader;
            selectedItem = obj;
            selectedItem.GetComponent<Renderer>().material.shader = outlineShader;
        }
        
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

}
