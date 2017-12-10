using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerOld : MonoBehaviour {

    public Animator AnimDescripUI;
    public GameObject DescripPanel;
    public GameObject ScanPanel;
    public Text TextDescripUI;
    public Button TakeItemButton;

    public void Start()
    {
        CloseDescriptionUI();
        ClearDescriptionText();
    }

    public void OpenDescriptionUI(GameObject obj, string description)
    {
        DescripPanel.SetActive(true);
        AnimDescripUI.Play("OpenUI");
        ChangeDescriptionText(description);
    }

    public void CloseDescriptionUI()
    {
        AnimDescripUI.Play("CloseUI");
    }

    private void ChangeDescriptionText(string description)
    {
        TextDescripUI.text = description;
    }

    private void ClearDescriptionText()
    {
        TextDescripUI.text = string.Empty;
        DescripPanel.SetActive(false);
    }

    public void OpenScanPanel()
    {
        ScanPanel.SetActive(true);
    }

    public void CloseScanPanel()
    {
        ScanPanel.SetActive(false);
    }
}
