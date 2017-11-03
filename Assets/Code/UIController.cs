using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Animator AnimDescripUI;
    public GameObject Panel;
    public Text TextDescripUI;
    public Button TakeItemButton;

    public void Start()
    {
        Panel.SetActive(false);
    }

    public void OpenDescriptionUI(GameObject obj,string description)
    {
        Panel.SetActive(true);
        AnimDescripUI.Play("OpenUI");
        ChangeDescriptionText(description);
        TakeItemButton.enabled = EnableTakeButton(obj); 
    }

    public void CloseDescriptionUI()
    {
        AnimDescripUI.Play("CloseUI");
        Invoke("ClearDescriptionText", 2);
    }

    private bool EnableTakeButton(GameObject obj)
    {
        if (obj.GetComponent<Item>())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void ChangeDescriptionText(string description)
    {
        TextDescripUI.text = description;
    }

    private void ClearDescriptionText()
    {
        TextDescripUI.text = string.Empty;
        Panel.SetActive(false);
    }
}
