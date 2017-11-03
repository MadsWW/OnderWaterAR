using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour  {

    public static Item selectedItem;

    private int score;
    private string name;
    private List<Item> inventory;

    public Player (string playerName)
    {
        name = playerName;
        score = 0;
        inventory = new List<Item>();
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void AddItemToInventory()
    {
        inventory.Add(selectedItem);
        selectedItem.DestroyItem();
    }

    public void RemoveItemFromInventory(Item item)
    {
        inventory.Remove(item);
    }

    public void EmptyInventory()
    {
        inventory.RemoveRange(0, inventory.Count);
    }
}