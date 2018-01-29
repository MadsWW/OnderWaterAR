using UnityEngine;
using UnityEngine.UI;


// !! Check if there are functions that can be combined. Ex. Open/Close bool function.
public class UIController : MonoBehaviour {

    public GameObject ScanPanel;


    // Adds methods to OnChangeLevel Event
    private void Start()
    {
        DefaultTrackableEventHandler.OnLevelChange += new DefaultTrackableEventHandler.LevelChanged(ChangeScanPanel);
    }

    private void OnDestroy()
    {
        DefaultTrackableEventHandler.OnLevelChange -= new DefaultTrackableEventHandler.LevelChanged(ChangeScanPanel);
    }

    // (De)Activetes scanpanel depending if there is an active level.
    private void ChangeScanPanel(GameObject activeLevel, bool isActive)
    {
        if (isActive)
        {
            ScanPanel.SetActive(true);
        }
        else if (!isActive)
        {
            ScanPanel.SetActive(false);
        }
    }
}
