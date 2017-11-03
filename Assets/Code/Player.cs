using System;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

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

    //Add points to score of player
    public void AddScore(int points)
    {
        score += points;
    }

    //Adds Item to players inventory
    public void AddItemToInventory(Item item)
    {
        inventory.Add(item);
    }

    //Takes away item from players inventory
    public void RemoveItemFromInventory(Item item)
    {
        inventory.Remove(item);
    }

    //Empties player entire inventory
    public void EmptyInventory()
    {
        inventory.RemoveRange(0, inventory.Count);
    }
}