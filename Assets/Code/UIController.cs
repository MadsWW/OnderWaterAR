﻿using UnityEngine;
using UnityEngine.UI;


// !! Check if there are functions that can be combined. Ex. Open/Close bool function.
public class UIController : MonoBehaviour {

    public GameObject ScanPanel;


    // Adds methods to OnChangeLevel Event
    private void Start()
    {
        DefaultTrackableEventHandler.OnLevelChange += ChangeScanPanel;
    }

    private void OnDestroy()
    {
        DefaultTrackableEventHandler.OnLevelChange -= ChangeScanPanel;
    }

    // (De)Activetes scanpanel depending if there is an active level.
    private void ChangeScanPanel(object sender, LevelChangeEventArgs args)
    {
        if (args.IsActive)
        {
            ScanPanel.SetActive(false);
        }
        else if (!args.IsActive)
        {
            ScanPanel.SetActive(true);
        }
    }
}
