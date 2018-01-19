using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_UI_Controller : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenExplenation()
    {
        anim.Play("Open_Expl");
    }

    public void CloseExplenation()
    {
        anim.Play("Close_Expl");
    }

}
