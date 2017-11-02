using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Animator animDescripUI;
    public Text textDescripUI;

    public void Start()
    {
        textDescripUI = GetComponentInChildren<Text>();
    }

    public void OpenDescriptionUI(string description)
    {
        animDescripUI.Play("OpenUI");
        ChangeDescriptionText(description);
    }

    public void CloseDescriptionUI()
    {
        animDescripUI.Play("CloseUI");
        Invoke("ClearDescriptionText", 2);
    }

    private void ChangeDescriptionText(string description)
    {
        textDescripUI.text = description;
    }

    private void ClearDescriptionText()
    {
        textDescripUI.text = string.Empty;
    }
}
