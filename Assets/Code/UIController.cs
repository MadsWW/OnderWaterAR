using UnityEngine;
using UnityEngine.UI;


// !! Check if there are functions that can be combined. Ex. Open/Close bool function.
public class UIController : MonoBehaviour {

    public GameObject ScanPanel;


    public void OpenScanPanel()
    {
        ScanPanel.SetActive(true);
    }

    public void CloseScanPanel()
    {
        ScanPanel.SetActive(false);
    }
}
