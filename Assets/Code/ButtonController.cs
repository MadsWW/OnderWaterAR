﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//!!Can be merged with UIController later on.
public class ButtonController : MonoBehaviour {

    public static Item selectedItem;

    public void TakeItem()
    {
        GameManager.player.AddItemToInventory(selectedItem);
        Destroy(selectedItem.gameObject);
    }
}
