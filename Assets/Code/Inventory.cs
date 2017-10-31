using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Inventory
{
    private List<Item> itemList = new List<Item>();


    public void AddItemToInventory (Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItemFromInventory(Item item)
    {
        itemList.Remove(item);
    }

}
