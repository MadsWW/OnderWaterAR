using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public static Item selectedItem;

    public void TakeItem()
    {
        GameManager.player.AddItemToInventory(selectedItem);
        Destroy(selectedItem.gameObject);
    }
}
